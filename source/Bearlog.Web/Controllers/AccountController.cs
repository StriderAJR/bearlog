using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bearlog.Web.Models;
using Bearlog.Web.Services;
using Newtonsoft.Json;

namespace Bearlog.Web.Controllers
{
    public class AccountController : Controller
    {
        DbService _dbService = new DbService();
        private const string UserNameCookie = "BearlogUserName";

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl, string key)
        {
            if (ModelState.IsValid)
            {
                if (_dbService.ValidateUser(model.UserName, model.Password))
                {
                    User user = _dbService.GetUser(model.UserName);
                    if (user == null) throw new NullReferenceException("Membership.GetUser");

                    BearlogPrincipalSerializeModel serializeModel = new BearlogPrincipalSerializeModel();
                    serializeModel.Id = user.Id;
                    serializeModel.UserName = user.UserName;
                    serializeModel.Roles = user.Roles;

                    SaveBearlogPrincipalSerializeModelCookie(model.UserName, serializeModel);

                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");

                    return new RedirectResult(returnUrl);
                }
                ModelState.AddModelError("AuthorizationError", "Логин или пароль введены неверно");
            }

            return RedirectToAction("Index", "Home");
        }

        private void SaveBearlogPrincipalSerializeModelCookie(string userName, BearlogPrincipalSerializeModel serializeModel)
        {
            string userData = JsonConvert.SerializeObject(serializeModel);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,                          // version
                         userName,                   // username
                         DateTime.Now,               // creation
                         DateTime.Now.AddMinutes(60),// Expiration
                         false,                      // Persistent
                         userData);                  // Userdata

            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            // Create a cookie and add the encrypted ticket to the 
            // cookie as data.
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Add the cookie to the outgoing cookies collection. 
            Response.Cookies.Add(authCookie);
            var cookie = new HttpCookie(UserNameCookie)
            {
                Value = userName,
                Expires = DateTime.Now.AddDays(5),
            };
            Response.SetCookie(cookie);
        }    

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            new DbService().AddUser(model);
            return View();
        }
    
    }
}