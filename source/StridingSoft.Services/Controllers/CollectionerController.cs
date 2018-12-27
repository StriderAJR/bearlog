using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StridingSoft.Services.Models.Collectioner;
using StridingSoft.Services.Services;

namespace StridingSoft.Services.Controllers {
    public class CollectionerController : Controller {
        private const string DbName = "CollectionerDb";

        public JsonResult Index() {
            return Json(new {Message = "Collectioner service v0.0.1"}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Register(string userName, string password, string email) {
            try {
                using (var db = new CollectionerEntities(Tools.GetConnectionString(DbName))) {
                    if (db.Users.Any(x => x.UserName == userName)) {
                        return Json(new {
                            isSuccess = false,
                            message = $"UserName {userName} is already taken"
                        }, JsonRequestBehavior.AllowGet);
                    }

                    // TODO validate correct email

                    db.Users.Add(new User {
                        UserName = userName,
                        Email = email,
                        Password = Hash.GetHashCode(password),
                        Role = db.Roles.First(x => x.Name == "User"),
                        RegDate = DateTime.Now,
                        LastActivityDate = null
                    });
                    db.SaveChanges();

                    return Json(new {isSuccess = true}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) {
                return Json(new {
                    isSuccess = false,
                    message = "Error in registration procedure",
                    details = e.Message,
                    stackTrace = e.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ChangeUserRole(string adminLogin, string token, string userName, int roleId) {
            try {
                return Json(new {
                    isSuccess = true,
                    message = "Just testing",
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) {
                return Json(new {
                    isSuccess = false,
                    message = "Error in registration procedure",
                    details = e.Message,
                    stackTrace = e.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult UserExists(string userName) {
            try {
                using (var db = new CollectionerEntities(Tools.GetConnectionString(DbName))) {
                    return Json(new {
                        exists = db.Users.Any(x => x.UserName == userName),
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) {
                return Json(new {
                    isSuccess = false,
                    message = "Error in registration procedure",
                    details = e.Message,
                    stackTrace = e.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Authenticate(string userName, string password) {
            try {
                using (var db = new CollectionerEntities(Tools.GetConnectionString(DbName))) {
                    if (db.Users.Any(x => x.UserName == userName)) {
                        var user = db.Users.First(x => x.UserName == userName);
                        if (user.Password == Hash.GetHashCode(password)) {
                            return Json(new {
                                isSuccess = true,
                                // this token will be required for all actions
                                token = Hash.GetHashCode(userName + Hash.GetHashCode(password))
                            }, JsonRequestBehavior.AllowGet);
                        }

                        return Json(new {
                            isSuccess = false,
                            message = "Wrong password"
                        }, JsonRequestBehavior.AllowGet);
                    }

                    return Json(new {
                        isSuccess = false,
                        message = $"User {userName} not found"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e) {
                return Json(new {
                    isSuccess = false,
                    message = "Error in authentication procedure",
                    details = e.Message,
                    stackTrace = e.StackTrace
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}