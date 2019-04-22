﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAMovie.Models
{
    public class Genre
    {
        [Display(Name="Genre")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}