using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(c => c.Genre)
                .Include(c => c.Rate)
                .ToList();


            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies
                .Include(c => c.Genre)
                .Include(c => c.Rate)
                .SingleOrDefault(c => c.Id == id);

            return View(movie);
        }


        // GET: Movies
        public ActionResult Random()
        {
            var movie = GetMovie();

            var customers = GetCustomers();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content("Route Attribute : " + year + "/" + month);
        }


        Movie GetMovie()
        {
            return new Movie { Name = "Movie 1" };
        }


        List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Movie 1" },
                new Movie { Name = "Movie 2" }
            };
        }


        List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
        }
    }
}