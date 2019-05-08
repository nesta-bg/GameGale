using System.Collections.Generic;

namespace GameGale.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> GameIds { get; set; }
    }
}