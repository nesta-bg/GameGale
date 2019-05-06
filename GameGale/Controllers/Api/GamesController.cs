using AutoMapper;
using GameGale.Dtos;
using GameGale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameGale.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/games
        public IHttpActionResult GetGames()
        {
            //ne treba () na kraju mapper.Map jer samo delegiramo na metod, ne pozivamo ga da se odmah izvrsi
            var gameDtos = _context.Games.ToList().Select(Mapper.Map<Game, GameDto>);

            return Ok(gameDtos);
        }

        //GET /api/games/1
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.Id == id);

            if (game == null)
                return NotFound();

            return Ok(Mapper.Map<Game, GameDto>(game));
        }

        //POST /api/games
        [HttpPost]
        //public Game PostGame(Game game) //ne treba [HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDto, Game>(gameDto);

            _context.Games.Add(game);
            _context.SaveChanges();

            gameDto.Id = game.Id;

            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
        }

        //PUT /api/games/1
        //return type could be Game or void
        [HttpPut]
        public IHttpActionResult UpdateGame(int id, GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return NotFound();

            //Mapper.Map<GameDto, Game>(gameDto, gameInDb);
            Mapper.Map(gameDto, gameInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/games/1
        [HttpDelete]
        public IHttpActionResult DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(g => g.Id == id);

            if (gameInDb == null)
                return NotFound();

            _context.Games.Remove(gameInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
