using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class ReturnPolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ReturnPolicy()
        {
            return View();
        }
    }
}
