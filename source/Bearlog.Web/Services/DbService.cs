using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bearlog.Web.Models;

namespace Bearlog.Web.Services
{
    public class DbService
    {
        public bool ValidateUser(string userName, string password)
        {
            return true;
        }

        public AccountModel GetUser(string userName)
        {
            return new AccountModel
            {
                Id = Guid.NewGuid(),
                UserName = "TestUser",
                Email = "test@test.com"
            };
        }
    }
}