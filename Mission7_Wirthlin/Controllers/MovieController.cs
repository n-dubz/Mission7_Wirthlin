using Microsoft.AspNetCore.Mvc;
using Mission7_Wirthlin.Data;
using Mission7_Wirthlin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mission7_Wirthlin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", movie.CategoryId);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", movie.CategoryId);
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}