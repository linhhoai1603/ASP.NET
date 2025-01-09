using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using ProjectDotNET.Models;
=======
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using System.Linq;

>>>>>>> 1eb1f536cd95872a69978e1e6dd71186a0dd64dd

namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {
<<<<<<< HEAD

        private readonly Shop_Context _context;

        public ProductsController(Shop_Context context)
        {
            _context = context;
        }

        public ActionResult Index()
=======
        private readonly Shop_Context context;
        public IActionResult Index()
>>>>>>> 1eb1f536cd95872a69978e1e6dd71186a0dd64dd
        {
            var products = context.Products.ToList();  
            return View(products);
        }
        [HttpGet]
<<<<<<< HEAD
        public ActionResult Products()
=======
        public IActionResult Products()

>>>>>>> 1eb1f536cd95872a69978e1e6dd71186a0dd64dd
        {
            var products = context.Products.ToList();  
            return View(products);
        }
        // Khởi tạo Shop_Context thông qua Dependency Injection
        public ProductsController(Shop_Context context)
        {
            this.context = context;
        }
    }
}
