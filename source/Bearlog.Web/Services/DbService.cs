using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Bearlog.Web.Models;

namespace Bearlog.Web.Services
{
  
    public class DbService
    {
        const string UserTableName = "[u0351346_Bearlog].[u0351346_developer].[Users]";

        private readonly string _getUsersCommand = string.Format("select * from {0}", UserTableName);
        private readonly string _addUserCommand = string.Format(
            @"
                    insert {0} 
                    (UserName, Password) 
                    values (@param1, @param2)", UserTableName);

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

        public bool AddUser(AccountModel model) //<-тут чето добавляется
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["BearlogDb"].ToString()))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var cmd = new SqlCommand(_addUserCommand, connection);

                cmd.Parameters.AddWithValue("@param1", model.UserName);
                cmd.Parameters.AddWithValue("@param2", model.Password);

                cmd.ExecuteNonQuery();

                return true;
            }
        } 

        public bool Validate(AccountModel model)
        {
            return false;
        }
    }
}