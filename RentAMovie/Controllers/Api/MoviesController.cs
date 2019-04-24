using AutoMapper;
using RentAMovie.Dtos;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentAMovie.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private DBEntity context;

        public MoviesController()
        {
            this.context = new DBEntity();
        }

        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            var moviesDTOs = this.context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(moviesDTOs);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = this.context.Movies.Single(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            this.context.Movies.Add(movie);
            this.context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = this.context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, movieInDb);

            this.context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = this.context.Movies.SingleOrDefault(m => m.Id == id);

            this.context.Movies.Remove(movieInDb);
            this.context.SaveChanges();
        }
    }
}
