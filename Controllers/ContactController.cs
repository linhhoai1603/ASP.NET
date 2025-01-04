using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
            public ActionResult Contact()
            {
                return View();
            }
    }
}
