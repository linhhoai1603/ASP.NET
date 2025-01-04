using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Products()
        {
            return View();
        }
    }
}
