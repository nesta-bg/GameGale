using System;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    [AllowAnonymous]
    //[OutputCache(Duration = 50)]
    public class HomeController : Controller
    {
        //we can cache date on the server or on the client.
        //if this view is specific to a given user we put it on the client, otherwise we put it on the server.
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server)]

        //if this action takes one or more parameters and output changes based on the value of those parameters we can cache each output separately.
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "genre")]

        //if we have multiple parameters we can use * so for any combination of those parameters we have a different version of the cache.
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]

        //how to disable caching.
        //[OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //simulating unhandled exception. We are getting the details about the exception.
            //But we want Custom Error Page: Shared/Error.cshtml
            //We go to Web.config
            throw new Exception();

            //ViewBag.Message = "Your application description page.";

            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}