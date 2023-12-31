﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Ch04Ex1MovieList.Models;
using Microsoft.EntityFrameworkCore;

namespace Ch04Ex1MovieList.Controllers
{
    public class HomeController : Controller
    {
        public MovieContext context { get; set; }

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre)
                .OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
