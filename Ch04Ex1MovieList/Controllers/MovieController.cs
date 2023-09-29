using Ch04Ex1MovieList.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch04Ex1MovieList.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add() 
        {
            ViewBag.Action = "Add";
            return View("Edit", new Movie());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieID == 0)
                    context.Movies.Add(movie);
                else
                    context.Movies.Update(movie);
                context.SaveChanges();
            }
            else
            {
                ViewBag.Action = (movie.MovieID == 0) ? "Add" : "Edit";
                return View(movie); 
            }

            return RedirectToAction("Index", "Home"); 
        }


        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
