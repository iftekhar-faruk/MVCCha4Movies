using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context { get; set; }

        //Constructor accepts DB Context object that's enabled by DI
        public HomeController(MovieContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var movies = Context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
