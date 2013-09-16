using System.Web.Mvc;
using System.Web.Routing;
using NGnono.Framework.Web.Mvc.Routes;

namespace NGnono.FMNote.WebSite4App.Core.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.{ext}/{*pathInfo}");

            routes.MapLowerCaseUrlRoute(
"Default_Page", // Route name
"{controller}/{action}/{page}", // URL with parameters
new { controller = "Home", action = "Index", id = 0, page = 1 } // Parameter defaults
, new { action = @".*List", page = @"\d*" } //正则列表页结尾 list
, null
);

            routes.MapLowerCaseUrlRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}