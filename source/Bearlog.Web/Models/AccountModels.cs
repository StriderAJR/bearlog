using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bearlog.Web.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

    public class AccountModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Is_Banned { get; set; }
        public bool Is_Active { get; set; }

    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }

    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}