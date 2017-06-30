using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Bearlog.Web.Models;
using Newtonsoft.Json;

namespace Bearlog.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null)
                {
                    BearlogPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<BearlogPrincipalSerializeModel>(authTicket.UserData);

                    if (serializeModel == null)
                        serializeModel = new BearlogPrincipalSerializeModel();

                    if (authTicket.Expired)
                    {
                        FormsAuthentication.SignOut();
                        HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                    }
                    else
                    {
                        BearlogPrincipal newUser = new BearlogPrincipal(User.Identity, serializeModel);
                        HttpContext.Current.User = newUser;
                    }
                }
            }
        }
    }
}
