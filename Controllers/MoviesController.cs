using System;
using System.Linq;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.ViewModels;
using System.Data.Entity;
using System.Diagnostics;

namespace VideoRental.Controllers
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

        //Get list of movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageAllMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            { 
                Genre = genre
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null) {
                return HttpNotFound();
            }

            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {
            try 
            {
                if (!ModelState.IsValid) 
                {
                    var viewModel = new MovieFormViewModel(movie)
                    {
                        Genre = _context.Genres.ToList()
                    };

                    return View("MovieForm", viewModel);
                }

                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.DateAdded = DateTime.Now;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageAllMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };
            
            return View("MovieForm", viewModel);
        }
    }
}