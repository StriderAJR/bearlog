using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Bearlog.Web.Controllers
{
    public class Tools
    {
        public static string GetConnectionString(string name)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[name]
                .ConnectionString;
            connectionString += "User ID=u0351346_striderajr;Password=ps^9wL31";
            return connectionString;
        }
    }

    /// <summary>
    /// Контроллер для другого моего проекта GenTrees
    /// Из-за сертификата SSL, который не распостраняется на поддомены,
    /// сервис будт жить здесь. Плак-плак
    /// </summary>
    public class GenTreesController : Controller
    {
        public JsonResult Index()
        {
            return Json(new {Message = "GenTrees service v0.0.2"}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TestMessage()
        {
            return Json(new {Message = "Greetings from ASP.NET RESTful service ^_^"}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TestDb()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GenTreesDb"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(Tools.GetConnectionString("GenTreesDb")))
                {
                    conn.Open();
                    return Json(new { Message = connectionString + "      =>     " + "Ok!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new {Message = connectionString + "      =>     " + "Fail :("}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}