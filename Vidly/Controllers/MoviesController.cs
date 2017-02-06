using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
           // List<Movie> movColl = _context.Movies.Include("Genere").ToList();
            if(User.IsInRole(UserRoles.CanManageMovies))
            return View("List");
            return View("ReadOnlyList");
        }

        // GET: Movies/Details/id
        public ActionResult Details(int id)
        {
            List<Movie> movColl = _context.Movies.Include("Genere").ToList();
            Movie selectedMovie = movColl.SingleOrDefault(x => x.Id == id);
            if (selectedMovie == null)
                return HttpNotFound();
            return View(selectedMovie);
        }

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ActionResult MovieDetail(int? id)
        {
           var viewModel = id.HasValue
                ? new MovieDetailsViewModel(_context.Movies.SingleOrDefault(x => x.Id == id))
                : new MovieDetailsViewModel();
            viewModel.Genere = _context.Generes.ToList();
           
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie selectedMovie)
        {
            if (!ModelState.IsValid)
            {
                var modelDetilasVieModel = new MovieDetailsViewModel(selectedMovie)
                {
                    
                    Genere = _context.Generes.ToList()
                };
                return View("MovieDetail", modelDetilasVieModel);
            }


            if (selectedMovie.Id == 0)
                _context.Movies.Add(selectedMovie);
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == selectedMovie.Id);
                movieInDb.Name = selectedMovie.Name;
                movieInDb.NumberInStock = selectedMovie.NumberInStock;
                movieInDb.ReleaseDate = selectedMovie.ReleaseDate;
                movieInDb.GenereId = selectedMovie.GenereId;
            }
            _context.SaveChanges();


            return RedirectToAction("index", "movies");
        }
    }
}