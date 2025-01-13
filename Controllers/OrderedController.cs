using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class OrderedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ordered()
        {
            return View();
        }
    }
}
