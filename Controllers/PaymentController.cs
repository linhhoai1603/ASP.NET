using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }
    }
}
