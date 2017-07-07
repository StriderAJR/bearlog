using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bearlog.Web.Models;
using Bearlog.Web.Services;

namespace Bearlog.Web.Controllers
{
    public class HomeController : Controller
    {
        DbService _dbService = new DbService();

        // GET: Home
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var user = ((BearlogPrincipal) User);
                var userName = user.UserName;
                var email = user.Email;


                //var books = _dbService.GetBooks();
                // ViewData["Books"] = books;
                // var books = _dbService.GetUserBooks(((BearlogPrincipal) User).Id);

                var model = _dbService.GetBooks();

                return View(model);
            }
            else
            {
                return View();
            }
        }
   
    }
}