using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using Bearlog.Web.Controllers;
using Bearlog.Web.Models;


namespace Bearlog.Web.Services
{

    public class DbService
    {
        const string UserTableName = "[u0351346_Bearlog].[u0351346_developer].[user]";
        const string BookTableName = "[u0351346_Bearlog].[u0351346_developer].[book]";
        const string PartTableName = "[u0351346_Bearlog].[u0351346_developer].[part]";
        const string TranslationTableName = "[u0351346_Bearlog].[u0351346_developer].[translation]";

        private readonly string _getPartsCommand = string.Format("select * from {0}", PartTableName);
        private readonly string _getBooksCommand = string.Format("select * from {0}", BookTableName);

        private readonly string _getBookCommand = string.Format("select * from {0} where user_name = @userName",
            BookTableName); // <-not work

        private readonly string _getUsersCommand = string.Format("select * from {0}", UserTableName);

        private readonly string _getUserCommand = string.Format("select * from {0} where user_name = @userName",
            UserTableName); // <-not work

        private readonly string _addUserCommand = string.Format(
            @"
                    insert {0} 
                    (user_id, user_name, password, email, is_banned, is_active) 
                    values 
                    (@param1,@param2, @param3,@param4,@param5, @param6)", UserTableName);

        private readonly string _addBookCommand = string.Format(@"
                    insert {0} 
                    (book_id, author_name, author_original_name, year) 
                    values 
                    (@param1,@param2, @param3,@param4)", BookTableName);

        private readonly string _addPartFragmentCommand = string.Format(@"
                    insert {0} 
                    (part_fragment_id, translation_id, original_text) 
                    values 
                    (@param1,@param2, @param3,@param4)", PartTableName);

        private readonly string _addTranslationModel = string.Format(
            @"
                    insert {0} 
                    (translation_id, tags, creator_id, name, name_original, from_language_id, to_language_id, cover_link, is_private, is_finished) 
                    values 
                    (@translation_id_param, @tags_param, @creator_id_param, @name_param, @name_original_param, @from_language_id_param, @to_language_id_param, @cover_link_param, @is_private_param, @is_finished )",
            TranslationTableName);

        #region User

        private User ConvertRowToUser(DataRow row)
        {
            return new User
            {
                Id = (Guid) row["user_id"],
                UserName = (string) row["user_name"],
                PasswordHash = (string) row["password"],
                Email = (string) row["email"],
                IsActive = (bool) row["is_active"],
                IsBanned = (bool) row["is_banned"]
            };
        }

        /// <summary>
        /// WARNING. Получить всех пользователей в системе
        /// </summary>
        /// <returns>Список всех пользоваталей</returns>
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection =
                new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_getUsersCommand, connection);
                var reader = cmd.ExecuteReader();
                var t = new DataTable();
                t.Load(reader);

                foreach (DataRow row in t.Rows)
                {
                    User u = ConvertRowToUser(row);
                    users.Add(u);
                }

                return users;
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <param name="userName">Логин в системе</param>
        /// <returns>Пользователь</returns>
        public User GetUser(string userName)
        {
            using (SqlConnection connection =
                new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_getUserCommand, connection);
                cmd.Parameters.AddWithValue("@userName", userName);
                var reader = cmd.ExecuteReader();
                var t = new DataTable();
                t.Load(reader);

                if (t.Rows.Count == 0)
                    return null;

                var userRow = t.Rows[0];
                return ConvertRowToUser(userRow);
            }
        }
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddUser(RegisterModel model)
        {
            using (SqlConnection connection = new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var cmd = new SqlCommand(_addUserCommand, connection);
                cmd.Parameters.AddWithValue("@param1", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@param2", model.UserName);
                cmd.Parameters.AddWithValue("@param3", Hash.GetHashCode(model.Password));
                cmd.Parameters.AddWithValue("@param4", model.Email);
                cmd.Parameters.AddWithValue("@param5", 0);
                cmd.Parameters.AddWithValue("@param6", 0);



                cmd.ExecuteNonQuery();

                return true;
            }
        }
        /// <summary>
        /// Проверить правильность пары логин и пароль
        /// </summary>
        /// <param name="userName">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Соответствуюет ли пара логин и пароль имеющимся в системе</returns>
        public bool ValidateUser(string userName, string password)
        {
            var user = GetUser(userName);
            if (user != null)
            {
                if (user.PasswordHash == Hash.GetHashCode(password))
                    return true;
            }

            return false;
        }
        #endregion

        /// <summary>
        /// WARNING. Получить все книги в системе
        /// </summary>
        /// <returns>Список всех книг</returns>
        public List<BookModel> GetBooks() 
        {
            List<BookModel> books = new List<BookModel>();
            using (SqlConnection connection =
                new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_getBooksCommand, connection);
                var reader = cmd.ExecuteReader();
                var t = new DataTable();
                t.Load(reader);

                List<Part> fragments1 = new List<Part>();
                var cmd1 = new SqlCommand(_getPartsCommand, connection);
                var reader1 = cmd.ExecuteReader();
                var t1 = new DataTable();
                t1.Load(reader1);

                foreach (DataRow row in t1.Rows)
                {
                    Part u = new Part()
                    {
                        Id = (Guid) row["part_id"],
                        Name = (string) row["name"],
                        OriginalName = (string) row["original_name"]
                    };
                    fragments1.Add(u);

                }

                foreach (DataRow row in t.Rows)
                {
                    BookModel u = new BookModel
                    {
                        Id = (Guid) row["book_id"],
                        AuthorName = (string) row["author_name"],
                        AuthorOriginalName = (string) row["author_original_name"],
                        Year = (int) row["year"],
                        Fragments = fragments1

                    };

                    books.Add(u);
                }

                return books;
            }
        }
        
        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="model">Книга</param>
        /// <param name="userId">Id пользователя, создавшего книгу</param>
        /// <param name="bookId">Id созданной книги</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddBook(BookModel model, Guid userId, out Guid bookId)
        {
            using (SqlConnection connection = new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var cmd2 = new SqlCommand(_addTranslationModel, connection);
                bookId = Guid.NewGuid();
                cmd2.Parameters.AddWithValue("@translation_id_param", bookId);

                string tags = null;
                if(model.Tags != null)
                    tags = string.Join(",", model.Tags);
                if (string.IsNullOrEmpty(tags))
                    cmd2.Parameters.AddWithValue("@tags_param",  DBNull.Value); 
                else
                    cmd2.Parameters.AddWithValue("@tags_param", tags);

                cmd2.Parameters.AddWithValue("@creator_id_param", userId);
                cmd2.Parameters.AddWithValue("@name_param",model.Name);
                cmd2.Parameters.AddWithValue("@name_original_param", model.OriginalName);
                cmd2.Parameters.AddWithValue("@from_language_id_param", model.FromLanguageId);
                cmd2.Parameters.AddWithValue("@to_language_id_param", model.ToLanguageId);
                if(string.IsNullOrEmpty(model.CoverLink))
                    cmd2.Parameters.AddWithValue("@cover_link_param", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@cover_link_param", model.CoverLink);
                cmd2.Parameters.AddWithValue("@is_private_param", model.IsPrivate);
                cmd2.Parameters.AddWithValue("@is_finished", 0);

                cmd2.ExecuteNonQuery();


                var cmd = new SqlCommand(_addBookCommand, connection);
                cmd.Parameters.AddWithValue("@param1", bookId);
                cmd.Parameters.AddWithValue("@param2", model.AuthorName);
                cmd.Parameters.AddWithValue("@param3", model.AuthorOriginalName);
                cmd.Parameters.AddWithValue("@param4", model.Year);                

                cmd.ExecuteNonQuery();

                return true;
            }

        }
        /// <summary>
        /// Добавить фрагмент перевода
        /// </summary>
        /// <param name="model">Фрагмент</param>
        /// <returns>Флаг успешности операции</returns>
        public bool AddPart(Part model)
        {
            using (SqlConnection connection = new SqlConnection(Tools.GetConnectionString("BearlogDb")))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                foreach (var fragment in model.Fragments)
                {
                    var cmd = new SqlCommand(_addPartFragmentCommand, connection);
                    cmd.Parameters.AddWithValue("@param1", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@param2", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@param3", fragment.OriginalText);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }

        }
    }
}