using GameGale.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    public class GamesController : Controller
    {
        public ViewResult Index()
        {
            var games = GetGames();
            return View(games);
        }

        private IEnumerable<Game> GetGames()
        {
            return new List<Game>
            {
                new Game { Id = 1, Name = "Control"},
                new Game { Id = 2, Name = "Among the Sleep"}
            };
        }
    }
}
