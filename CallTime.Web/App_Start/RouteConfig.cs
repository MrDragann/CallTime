using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CallTime.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultLangEdit",
                url: "{lang}/{edit}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"ru|en", edit = @"edit" },
                namespaces: new[] { "CallTime.Web.Controllers" }
            );

            routes.MapRoute(
                name: "DefaultLang",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, edit = "" },
                constraints: new { lang = @"ru|en" },
                namespaces: new[] { "CallTime.Web.Controllers" }
            );

            routes.MapRoute(
                name: "DefaultEdit",
                url: "{edit}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "ru" },
                constraints: new { edit = @"edit" },
                namespaces: new[] { "CallTime.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "ru", edit ="" },
                namespaces: new[] { "CallTime.Web.Controllers" }
            );
        }
    }
}
