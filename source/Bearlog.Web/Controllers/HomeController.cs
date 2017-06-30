using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearlog.Web.Models;

namespace Bearlog.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var user = ((BearlogPrincipal) User);
                var userName = user.UserName;
                var email = user.Email;
            }

            var users = new DbService().GetUsers();
            ViewData["users"] = users;

            return View();
        }
    }
}