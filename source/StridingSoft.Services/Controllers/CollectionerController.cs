using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StridingSoft.Services.Models.Collectioner;
using StridingSoft.Services.Services;

namespace StridingSoft.Services.Controllers
{
    public class CollectionerController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { Message = "Collectioner service v0.0.1" }, JsonRequestBehavior.AllowGet);
        }

        public bool UserExists(string userName)
        {
            try
            {
                using (var db = new CollectionerEntities(Tools.GetConnectionString("CollectionerDb")))
                {
                    return db.users.Any(x => x.user_name == userName);
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}