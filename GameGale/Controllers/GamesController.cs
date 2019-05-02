using GameGale.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var games = _context.Games.Include(g => g.Genre).ToList();

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }
    }
}
