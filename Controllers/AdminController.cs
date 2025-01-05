using Microsoft.AspNetCore.Mvc;

namespace ProjectDotNET.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerUser()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerMessage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerOrder()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerPayment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerProduct()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerWareHouse()
        {
            return View();
        }
    }
}
