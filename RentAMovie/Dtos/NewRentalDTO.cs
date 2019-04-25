using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.Dtos
{
    public class NewRentalDTO
    {
        public int Id { get; set; }
        public List<int> MovieIds { get; set; }
    }
}