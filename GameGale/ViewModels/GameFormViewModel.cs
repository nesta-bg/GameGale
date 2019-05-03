using GameGale.Models;
using System.Collections.Generic;

namespace GameGale.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Game Game { get; set; }
        public string Title
        {
            get
            {
                if (Game != null && Game.Id != 0)
                    return "Edit Game";

                return "New Game";
            }
        }
    }
}