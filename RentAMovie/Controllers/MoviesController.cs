﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Caching;
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
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var movie = this.context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = this.context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie
                {
                    ReleaseDate = DateTime.ParseExact("01.01.0001", "dd.MM.yyyy", null)
                },
                Genre = genres
            };

            return View("MoviesForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = this.context.Genres.ToList()
                };

                return View("MoviesForm", viewModel);
            }

            // Add a new movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                this.context.Movies.Add(movie);
            }
            // Edit an existing movie
            else
            {
                var movieInDb = this.context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;     
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            this.context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}