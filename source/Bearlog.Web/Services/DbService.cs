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
                var cmd = new SqlCommand("select * from [u0351346_Bearlog].[u0351346_developer].[User]", _connection);
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

        public bool Validate(AccountModel model)
        {
            return false;
        }
    }
}