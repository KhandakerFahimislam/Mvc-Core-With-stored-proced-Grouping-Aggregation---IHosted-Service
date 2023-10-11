using Microsoft.AspNetCore.Mvc;

namespace Project_1273081_M09_P1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
