using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAMovie.Models;
using RentAMovie.ViewModels;

namespace RentAMovie.Controllers
{
    public class MoviesController : Controller
    {
        private DBEntity context;

        public MoviesController()
        {
            this.context = new DBEntity();
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = this.context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = this.context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = this.context.Movies.SingleOrDefault(m => m.Id == id);
            var genres = this.context.Genres.ToList();

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = genres
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult New()
        {
            var genres = this.context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.Genre = FindTheGenreFromId(movie.Genre.Id);
                this.context.Movies.Add(movie);
            }
                
            else
            {
                var movieInDb = this.context.Movies.Single(m => m.Id == movie.Id);
                var genre = this.context.Genres.Single(g => g.Id == movie.Genre.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = genre;     
                movieInDb.Stock = movie.Stock;
            }

            this.context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        private Genre FindTheGenreFromId(int id)
        {
            return this.context.Genres.Single(g => g.Id == id);
        }
    }
}