using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gam3iaWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                    name: "CaseStudies",
                    url: "CaseStudies/{action}/{id}",
                    defaults: new
                    {
                        controller = "CaseStudies",
                        action = "Index",
                        id = UrlParameter.Optional
                    }
                );
            routes.MapRoute(
                   name: "Poors",
                   url: "Poors/{action}/{id}",
                   defaults: new
                   {
                       controller = "Poors",
                       action = "Index",
                       id = UrlParameter.Optional
                   }
               );
            routes.MapRoute(
                   name: "Loans",
                   url: "Loans/{action}/{id}",
                   defaults: new
                   {
                       controller = "Loans",
                       action = "Index",
                       id = UrlParameter.Optional
                   }
               );
           
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                
            );
        }
    }
}
