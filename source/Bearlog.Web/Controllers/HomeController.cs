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


                var users = new DbService().GetUsers();
                ViewData["users"] = users;

                BookModel model = new BookModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Lord of the Rings",
                    AuthorName = "Джон Рональд Руэл Толкин",
                    AuthorOriginalName = "John Ronald Reuel Tolkien",
                    Year = 1955
                };

                // var books = _dbService.GetUserBooks(((BearlogPrincipal) User).Id);

                return View(model);
            }
            else
            {
                return View();
            }
        }
   
    }
}