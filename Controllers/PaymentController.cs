using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
