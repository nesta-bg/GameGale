﻿using GameGale.Dtos;
using GameGale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

namespace GameGale.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/newrentals/1
        public IHttpActionResult GetNewRentals(int Id)
        {
            var rentals = _context.Rentals
                .Include(r => r.Game)
                .Where(r => r.Customer.Id == Id && r.DateReturned == null)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentals);
        }

        /* POSTMAN TEST
        {
            "customerId": 1,
            "gameIds": [1, 2, 3]
        }
        */
        //POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRenatals(NewRentalDto newRentalDto)
        {
            /*
            if (newRentalDto.GameIds.Count == 0)
                return BadRequest("No Game Ids have been given.");
            */
            /*
            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == newRentalDto.CustomerId);

             if (customer == null)
                return BadRequest("CustomerId is not valid.");
            */
            var customer = _context.Customers
                .Single(c => c.Id == newRentalDto.CustomerId);

            //SELECT * FROM Games WHERE Id IN (1,2,3)
            //bez ToList() vraca IQueryable<Game>
            var games = _context.Games
                .Where(g => newRentalDto.GameIds.Contains(g.Id)).ToList();

            /*
           if (games.Count != newRentalDto.GameIds.Count)
               return BadRequest("One or more GameIds are invalid.");
           */

            foreach (var game in games)
            {
                if (game.NumberInStock == 0)
                    return BadRequest("Game is not available.");
                    
                game.NumberAvailable--;
                
                var rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now,
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        //PUT /api/newrentals/1
        [HttpPut]
        public IHttpActionResult ReturnRental(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Game)
                .SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return NotFound();

            rental.Game.NumberAvailable++;
            rental.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        //PUT /api/newrentals
        [HttpPut]
        public IHttpActionResult ReturnAllRentalsForCustomer(NewRentalDto newRentalDto)
        {
            var allRentals = _context.Rentals
                .Include(r => r.Game)
                .Where(r => r.Customer.Id == newRentalDto.CustomerId && r.DateReturned == null)
                .ToList();

            foreach (var rental in allRentals)
            {
                rental.Game.NumberAvailable++;
                rental.DateReturned = DateTime.Now;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
