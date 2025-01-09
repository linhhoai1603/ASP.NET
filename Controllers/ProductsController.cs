using Microsoft.AspNetCore.Mvc;
using ProjectDotNET.Models;

namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {

        private readonly Shop_Context _context;

        public ProductsController(Shop_Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products()
        {
            return View();
        }
    }
}
