using RentAMovie.Dtos;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentAMovie.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private DBEntity context;

        public NewRentalsController()
        {
            this.context = new DBEntity();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRentalDTO)
        {
            var customer = this.context.Customers.Single(c => c.Id == newRentalDTO.CustomerId);
            var movies = this.context.Movies.Where(m => newRentalDTO.MovieIds.Contains(m.Id));

            foreach(var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                this.context.Rentals.Add(rental);
            }

            this.context.SaveChanges();

            return Ok();
        }
    }
}
