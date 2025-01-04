using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Policy()
        {
            return View();
        }
    }
}
