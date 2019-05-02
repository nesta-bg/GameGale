﻿using GameGale.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GameGale.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Johnny Depp"},
                new Customer { Id = 2, Name = "Steve Jobs"}
            };
        }
    }
}