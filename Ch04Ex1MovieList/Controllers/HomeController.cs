using Microsoft.AspNetCore.Mvc;

namespace Ch04Ex1MovieList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
