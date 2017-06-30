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

        private readonly string _getUsersCommand = string.Format("select * from {0}", UserTableName);
        private readonly string _getUserCommand = string.Format("select * from {0} where user_name = @userName", UserTableName);
        private readonly string _addUserCommand = string.Format(
            @"
                    insert {0} 
                    (user_id, user_name, password, email, is_banned, is_active) 
                    values 
                    (@param1,@param2, @param3,@param4,@param5, @param6)", UserTableName);

        private readonly string _addBookCommand = string.Format(@"
                    insert {0} 
                    (book_id, author_name, author_original_name, year,translation_id) 
                    values 
                    (@param1,@param2, @param3,@param4,@param5)", BookTableName);

        private readonly string _addPartFragmentCommand = string.Format(@"
                    insert {0} 
                    (part_fragment_id, translation_id, original_text) 
                    values 
                    (@param1,@param2, @param3,@param4)", PartTableName);

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection _connection =
                new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                var cmd = new SqlCommand(_getUsersCommand, _connection);
                var reader = cmd.ExecuteReader();
                var t = new DataTable();
                t.Load(reader);

                foreach (DataRow row in t.Rows)
                {
                    User u = new User
                    {
                        UserName = (string) row["user_name"],
                        Email = (string) row["email"]
                    };
                    users.Add(u);
                }

                return users;
            }
        }

        public User GetUser(string userName)
        {
            // TODO Переделать на SqlCommand, чтобы не выгружать всех пользователей ради одного
            return GetUsers().FirstOrDefault(x => x.UserName == userName);
        }


        public bool AddUser(RegisterModel model) //<-тут чето добавляется
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
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

        public bool AddBook(BookModel model)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_addBookCommand, connection);
                cmd.Parameters.AddWithValue("@param1", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@param2", model.AuthorName);
                cmd.Parameters.AddWithValue("@param3", model.AuthorOriginalName);
                cmd.Parameters.AddWithValue("@param4", model.Year);
                cmd.Parameters.AddWithValue("@param4", Guid.NewGuid());

                cmd.ExecuteNonQuery();

                return true;
            }

        }

        public bool AddPart(PartFragment model)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_addPartFragmentCommand, connection);
                cmd.Parameters.AddWithValue("@param1", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@param2", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@param3", model.OriginalText);

                cmd.ExecuteNonQuery();

                return true;
            }

        }

        public bool ValidateUser(string userName, string password)
        {
            var users = GetUsers();
            foreach (var user in users)
            {
                if (user.UserName == userName)
                {
                    // проверяем пароль
                    return true;
                }
            }

            var user2 = users.FirstOrDefault(x => x.UserName == userName);
            if (user2 != null)
            {
                // проверяем пароль
            }

            return false;
        }
    }
}