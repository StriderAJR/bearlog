using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StridingSoft.Services.Services
{
    public class Tools
    {
        public static string GetConnectionString(string name)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;

            string dbUser = Resources.Secret.ResourceManager.GetString($"{name}_User");
            string dbPassword = Resources.Secret.ResourceManager.GetString($"{name}_Password");

            connectionString += $"User ID={dbUser};Password={dbPassword}";
            return connectionString;
        }
    }
}