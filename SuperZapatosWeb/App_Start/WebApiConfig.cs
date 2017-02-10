using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace SuperZapatosWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "articles",
                routeTemplate: "services/articles/stores/{id}",
                defaults: new { controller = "stores", action = "GetArticlesByStore", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "stores",
                routeTemplate: "services/stores/",
                defaults: new { controller = "Stores", action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "articls",
                routeTemplate: "services/articles/",
                defaults: new { controller = "Articles", action = "Get" }
            );
        }
    }
}
