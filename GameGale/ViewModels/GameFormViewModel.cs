using GameGale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameGale.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Game" : "New Game";
            }
        }

        public GameFormViewModel()
        {
            Id = 0;
        }

        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            NumberInStock = game.NumberInStock;
            GenreId = game.GenreId;
        }
    }
}