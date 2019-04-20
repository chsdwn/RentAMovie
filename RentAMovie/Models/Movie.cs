using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        [Column(TypeName="date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
    }
}