using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}