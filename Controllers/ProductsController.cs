using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace ProjectDotNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Shop_Context context;

        public ProductsController(Shop_Context context)
        {
            this.context = context;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var products = context.Products
                                  .Include(p => p.Brand)
                                  .Include(p => p.Category)
                                  .Include(p => p.ProductSpecification)
                                  .Include(p => p.Warehouse)
                                  .OrderBy(p => p.ProductId)
                                  .ToPagedList(pageNumber, pageSize);

            return View(products);
        }
        [HttpGet]
        public IActionResult Products(int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var model = context.Products
                               .Include(p => p.Brand)
                               .Include(p => p.Category)
                               .Include(p => p.ProductSpecification)
                               .Include(p => p.Warehouse)
                               .OrderBy(p => p.ProductId)
                               .ToPagedList(pageNumber, pageSize);

            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = context.Products
                .Include(p => p.Brand)                    // Thương hiệu
                .Include(p => p.Category)                 // Danh mục
                .Include(p => p.ProductSpecification)     // Thông số kỹ thuật
                .Include(p => p.Warehouse)                // Kho hàng
                .Include(p => p.Colors)                   // Màu sắc
                .FirstOrDefault(p => p.ProductId == id);  // Lấy sản phẩm theo ID

            if (product == null)
            {
                return NotFound(); // Nếu không tìm thấy sản phẩm
            }
            return View(product); // Trả về View với dữ liệu sản phẩm
        }

    }
}
