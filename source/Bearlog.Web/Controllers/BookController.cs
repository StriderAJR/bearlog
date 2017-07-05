using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using Bearlog.Web.Models;

using Bearlog.Web.Services;



namespace Bearlog.Web.Controllers

{



    public class BookController : Controller

    {

        DbService _dbService = new DbService();



        [Authorize]

       

        // bearlog.org/Book/bookId

        public ActionResult Index(Guid id)

        {
            //Передаем

            // var book = _dbService.GetBook(bookId);
            BookModel book = new BookModel
            {
                Name = "Ведьмак"
            };
            return View(book); // Возвращаем в вид МОДЕЛЬ!

        }



        [HttpPost]

        public ActionResult InsertPart (Part model) // insertPart - название страницы?

        {

            new DbService().AddPart(model);

            return View();

        }



        public ActionResult Add()

        {
            List<Language> languages = new List<Language>
            {
                new Language { Id = Guid.NewGuid(), Name = "Русский"},
                new Language { Id = Guid.NewGuid(), Name = "Английский"}
            };

            ViewData["Languages"] = languages;

            return View();

        }



        [HttpPost]

        public ActionResult Add(BookModel model)

        {
            List<Language> languages = new List<Language>
            {
                new Language { Id = Guid.NewGuid(), Name = "Русский"},
                new Language { Id = Guid.NewGuid(), Name = "Английский"}
            };

            ViewData["Languages"] = languages;

            Guid bookId;
            _dbService.AddBook(model, ((BearlogPrincipal)User).Id, out bookId); // Стало

            return RedirectToAction("Index", new { id = bookId});

        }
    }
}







