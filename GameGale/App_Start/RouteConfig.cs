using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameGale
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //from most specific to most generic route
            /*
            routes.MapRoute(
               "GamesByReleaseDate",                                                        //name
               "games/released/{year}/{month}",                                             //url       
               new { controller = "Games", action = "ByReleaseDate" },                      //defaults
               new { year = @"2015|2016", month = @"\d{2}" }                                //constraints 
            );
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
