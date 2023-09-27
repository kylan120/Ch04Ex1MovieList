using Microsoft.AspNetCore.Mvc;

namespace Ch04Ex1MovieList.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
