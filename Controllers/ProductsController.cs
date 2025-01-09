using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using System.Linq;


namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Shop_Context context;
        public IActionResult Index()
        {
            var products = context.Products.ToList();  
            return View(products);
        }
        [HttpGet]
        public IActionResult Products()

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
