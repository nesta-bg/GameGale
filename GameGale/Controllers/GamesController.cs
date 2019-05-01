using GameGale.Models;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Random()
        {
            var game = new Game() { Name = "Metro Exodus" };
            return View(game);
        }
    }
}