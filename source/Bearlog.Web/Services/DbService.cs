using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using Bearlog.Web.Models;


namespace Bearlog.Web.Services
{

    public class DbService
    {
        const string UserTableName = "[u0351346_Bearlog].[u0351346_developer].[user]";
        const string BookTableName = "[u0351346_Bearlog].[u0351346_developer].[book]";
        const string PartTableName = "[u0351346_Bearlog].[u0351346_developer].[part]";
        const string TranslationTableName = "[u0351346_Bearlog].[u0351346_developer].[translation]";

        private readonly string _getTranslationsCommand = string.Format("select * from {0}", TranslationTableName);

        #region User

        private User ConvertRowToUser(DataRow row)
        {
            return new User
            {
                Id = (Guid)row["id"],
                UserName = (string)row["user_name"],
                PasswordHash = (string)row["password"],
                Email = (string)row["email"],
                IsActive = (bool)row["is_active"],
                IsBanned = (bool)row["is_banned"]
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
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string getUsersCommand = string.Format("select * from {0}", UserTableName);

                var cmd = new SqlCommand(getUsersCommand, connection);
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
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string getUserCommand = string.Format("select * from {0} where user_name = @userName", UserTableName);

                var cmd = new SqlCommand(getUserCommand, connection);
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
            using (SqlConnection connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string addUserCommand = string.Format(
                    @"
                        insert {0} 
                        (id, user_name, password, email, is_banned, is_active) 
                        values 
                        (@id, @user_name, @password, @email, @is_banned, @is_active)
                    ", UserTableName);

                var cmd = new SqlCommand(addUserCommand, connection);
                cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@user_name", model.UserName);
                cmd.Parameters.AddWithValue("@password", Hash.GetHashCode(model.Password));
                cmd.Parameters.AddWithValue("@email", model.Email);
                cmd.Parameters.AddWithValue("@is_banned", 0);
                cmd.Parameters.AddWithValue("@is_active", 0);

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
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string _getBooksCommand = string.Format("select * from {0}", BookTableName);

                var getBooksCmd = new SqlCommand(_getBooksCommand, connection);
                var reader = getBooksCmd.ExecuteReader();
                var booksTable = new DataTable();
                booksTable.Load(reader);

                string getPartsCommand = string.Format("select * from {0}", PartTableName);

                var getPartsCmd = new SqlCommand(getPartsCommand, connection);
                reader = getPartsCmd.ExecuteReader();
                var partsTable = new DataTable();
                partsTable.Load(reader);

                foreach (DataRow row in booksTable.Rows)
                {
                    BookModel u = new BookModel
                    {
                        Id = (Guid)row["id"],
                        AuthorName = (string)row["author_name"],
                        AuthorOriginalName = (string)row["author_original_name"],
                        Year = (int)row["year"]
                    };

                    var partsTableAsEnumerble = partsTable.AsEnumerable();
                    var thisBookParts = partsTableAsEnumerble.Where(x => x.Field<Guid>("translation_id") == u.Id);
                    u.Parts = thisBookParts.Select(x => new Part
                    {
                        Id = (Guid)x["id"],
                        Name = (string)x["name"],
                        OriginalName = (string)x["original_name"]
                    }).ToList();

                    books.Add(u);
                }

                return books;
            }
        }

        private BookModel ConvertRowToBook(DataRow translationRow, DataRow bookRow)
        {
            return new BookModel
            {
                Id = (Guid)translationRow["id"],
                Tags = (string[])translationRow["tags"],
                CreatorId = (Guid)translationRow["creator_id"],
                Name = (string)translationRow["name"],
                OriginalName = (string)translationRow["name_original"],
                FromLanguageId = (Guid)translationRow["from_language_id"],
                ToLanguageId = (Guid)translationRow["to_language_id"],
                CoverLink = (string)translationRow["cover_link"],
                IsPrivate = (bool)translationRow["is_private"],
                IsFinished = (bool)translationRow["is_finished"],

                AuthorName = (string)bookRow["author_name"],
                AuthorOriginalName = (string)bookRow["author_original_name"],
                Year = (int)bookRow["year"]

            };
        }

        public List<BookModel> GetUserBooks(Guid userId)
        {
            List<BookModel> books = new List<BookModel>();
            using (SqlConnection connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string getUserTranslationsCommand = string.Format("select * from {0} where creator_id = @creator_id", TranslationTableName);

                var cmd = new SqlCommand(getUserTranslationsCommand, connection);
                cmd.Parameters.AddWithValue("@creator_id", userId);
                var reader = cmd.ExecuteReader();
                var translationRawTable = new DataTable();
                translationRawTable.Load(reader);
                var translationTable = translationRawTable.AsEnumerable();
                var bookIds = translationTable.Select(x => x.Field<Guid>("id")).ToList();

                string getUserBooksCommand = string.Format("select * from {0} where id in (@book_ids)", BookTableName);

                cmd = new SqlCommand(getUserBooksCommand, connection);
                cmd.Parameters.AddWithValue("@book_ids", string.Join(",", bookIds.Select(x => x.ToString())));
                reader = cmd.ExecuteReader();
                var booksRawTable = new DataTable();
                booksRawTable.Load(reader);
                var booksTable = booksRawTable.AsEnumerable();

                foreach (DataRow translationRow in translationTable)
                {
                    var bookRow = booksTable.FirstOrDefault(x => x.Field<Guid>("id") == translationRow.Field<Guid>("id"));
                    if (bookRow == null)
                        throw new Exception();

                    books.Add(ConvertRowToBook(translationRow, bookRow));
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
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string addTranslationModel = string.Format(
                    @"
                        INSERT {0} 
                        (id, tags, creator_id, name, name_original, from_language_id, to_language_id, cover_link, is_private, is_finished) 
                        VALUES 
                        (@translation_id, @tags, @creator_id, @name, @name_original, @from_language_id, @to_language_id, @cover_link, @is_private, @is_finished )
                    ", TranslationTableName);

                var cmd2 = new SqlCommand(addTranslationModel, connection);
                bookId = Guid.NewGuid();
                cmd2.Parameters.AddWithValue("@translation_id", bookId);

                string tags = null;
                if (model.Tags != null)
                    tags = string.Join(",", model.Tags);
                if (string.IsNullOrEmpty(tags))
                    cmd2.Parameters.AddWithValue("@tags", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@tags", tags);

                cmd2.Parameters.AddWithValue("@creator_id", userId);
                cmd2.Parameters.AddWithValue("@name", model.Name);
                cmd2.Parameters.AddWithValue("@name_original", model.OriginalName);
                cmd2.Parameters.AddWithValue("@from_language_id", model.FromLanguageId);
                cmd2.Parameters.AddWithValue("@to_language_id", model.ToLanguageId);
                if (string.IsNullOrEmpty(model.CoverLink))
                    cmd2.Parameters.AddWithValue("@cover_link", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@cover_link", model.CoverLink);
                cmd2.Parameters.AddWithValue("@is_private", model.IsPrivate);
                cmd2.Parameters.AddWithValue("@is_finished", 0);

                cmd2.ExecuteNonQuery();

                string addBookCommand = string.Format(
                    @"
                        INSERT {0} 
                        (id, author_name, author_original_name, year) 
                        VALUES 
                        (@id,@author_name, @author_original_name,@year)
                    ", BookTableName);

                var cmd = new SqlCommand(addBookCommand, connection);
                cmd.Parameters.AddWithValue("@id", bookId);
                cmd.Parameters.AddWithValue("@author_name", model.AuthorName);
                cmd.Parameters.AddWithValue("@author_original_name", model.AuthorOriginalName);
                cmd.Parameters.AddWithValue("@year", model.Year);

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
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string addPartFragmentCommand = string.Format
                    (@"
                        INSERT {0} 
                        (id, translation_id, original_text) 
                        VALUES 
                        (@id,@translation_id, @original_text)
                    ", PartTableName);

                foreach (var fragment in model.Fragments)
                {
                    var cmd = new SqlCommand(addPartFragmentCommand, connection);
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@translation_id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@original_text", fragment.OriginalText);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }

        }
    }
}