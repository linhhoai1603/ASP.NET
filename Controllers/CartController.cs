using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
