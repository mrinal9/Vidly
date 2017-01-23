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
            List<Movie> movColl = _context.Movies.Include("Genere").ToList();
            return View(movColl);
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

        public ActionResult MovieDetail(int? id)
        {
            var viewModel = new MovieDetailsViewModel()
            {
                SelectedMovie = _context.Movies.SingleOrDefault(x=>x.Id==id),
                Genere = _context.Generes.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie selectedMovie)
        {
            if(selectedMovie.Id==0)
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
          
           
            return RedirectToAction("index","movies");
        }
    }
}