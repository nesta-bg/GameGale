using GameGale.Models;
using System;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    public class GamesController : Controller
    {
        /************ACTION RESULTS*******************/
        
        //ActionResult is the base class for all action classes in ASP.NET MVC https://www.c-sharpcorner.com/article/action-result-in-asp-net-mvc/
        //Depending what the action does it will return an instance of one of the classes that derives from ActionResult
        //ViewResult,PartialViewResult,ContentResult,RedirectResult,RedirectToRouteResult,JsonResult,FileResult,HttpNotFoundResult,EmptyResult
        public ActionResult Random()
        {
            var game = new Game() { Name = "Metro Exodus" };
            //return new ViewResult(game); 
            //View() - helper mathod that derives from base Controller class
            return View(game);

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        /************ACTION PARAMETERS*******************/

        //GET: Games/Edit/1
        //GET: Games/Edit?id=1
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //GET: Games/Edit?id=1 - error
        //GET: Games/Edit/1 - error. Gore je moglo jer je id default ovde ne moze
        //GET: Games/Edit?gameId=1 - ok
        /*
        public ActionResult Edit(int gameId)
        {
            return Content("id=" + gameId);
        }
        */

        //GET: Games
        //GET: Games?pageIndex=2
        //GET: Games?pageIndex=2&sortBy=ReleaseDate
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex ={0}&sortBy={1}", pageIndex, sortBy));
        }

        //mvcaction4 tab
        //GET: games/released/2015/4 error
        //GET: games/released/2015/04 ok
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
