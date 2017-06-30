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
        [Authorize]
       // [HttpPost]
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertPart (PartFragment model) // insertPart - название страницы?
        {
            new DbService().AddPart(model);
            return View();
        }

    }
}