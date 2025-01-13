using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using System.Linq;

namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Shop_Context context;

        public ProductsController(Shop_Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // Nạp thêm dữ liệu Brand, Category, ProductSpecification, Warehouse
            var products = context.Products
                                  .Include(p => p.Brand)
                                  .Include(p => p.Category)
                                  .Include(p => p.ProductSpecification)
                                  .Include(p => p.Warehouse)
                                  .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Products()
        {
            var model = context.Products
                               .Include(p => p.Brand)
                               .Include(p => p.Category)
                               .Include(p => p.ProductSpecification)
                               .Include(p => p.Warehouse)
                               .ToList();

            if (model == null || !model.Any())
            {
                return View("Error"); // Trả về trang lỗi nếu không có sản phẩm
            }
            return View(model);
        }
    }
}
