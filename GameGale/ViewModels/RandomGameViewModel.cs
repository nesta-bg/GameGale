using GameGale.Models;
using System.Collections.Generic;

namespace GameGale.ViewModels
{
    public class RandomGameViewModel
    {
        public Game Game { get; set; }
        public List<Customer> Customers { get; set; }
    }
}