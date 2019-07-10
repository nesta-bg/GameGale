using System;

namespace GameGale.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public GameDto Game { get; set; }
        public DateTime DateRented { get; set; }
    }
}