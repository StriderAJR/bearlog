using System.Web.Mvc;
using System.Web.Routing;

namespace StridingSoft {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                            name: "Default",
                            url: "{controller}/{action}/{id}",
                            defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                           );
        }
    }

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}