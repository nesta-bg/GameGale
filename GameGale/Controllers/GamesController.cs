using GameGale.Models;
using GameGale.ViewModels;
using System;
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
            return View();
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GameFormViewModel
            {
                Genres = genres
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(m => m.Id == game.Id);

                //TryUpdateModel(gameInDb);
                //TryUpdateModel(gameInDb, "", new string[] { "Name", "GenreId" });

                //Mapper.Map(game, gameInDb);

                gameInDb.Name = game.Name;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        public ActionResult Edit(int id)
        {
            var genres = _context.Genres.ToList();
            var game = _context.Games.SingleOrDefault(g => g.Id == id);
            
            var viewModel = new GameFormViewModel(game)
            {
                Genres = genres
            };

            return View("GameForm", viewModel);
        }
    }
}
