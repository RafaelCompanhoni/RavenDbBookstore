using System.Web.Mvc;
using System.Web.Routing;

namespace Bookstore.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Categories",
                url: "{controller}/{action}/{category}/{subcategory}/{id}",
                defaults: new { controller = "Dashboard", action = "Index", category = "dashboard", subcategory = "dashboard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
