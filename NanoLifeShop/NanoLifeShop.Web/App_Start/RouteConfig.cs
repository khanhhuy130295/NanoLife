﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NanoLifeShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Post",
                url: "post",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PostDetail",
                url: "tin-tuc/{alias}-{id}",
                defaults: new { controller = "Post", action = "Detail", id = UrlParameter.Optional }
             );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
