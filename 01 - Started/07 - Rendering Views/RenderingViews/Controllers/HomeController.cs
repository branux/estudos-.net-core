using Microsoft.AspNetCore.Mvc;

namespace RenderingViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return new ObjectResult(new
            {
                Id = 1,
                Nome = "Fabiano Nalin"
            });
        }
    }
}
