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
        public IActionResult Products(string brand, string priceRange, string storage, string sortOption, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var products = context.Products
                               .Include(p => p.Brand)
                               .Include(p => p.Category)
                               .Include(p => p.ProductSpecification)
                               .Include(p => p.Warehouse)
                               .OrderBy(p => p.ProductId)
                               .AsQueryable();
            if (!string.IsNullOrEmpty(brand))
            {
                products = products.Where(p => p.Brand.BrandName.ToUpper() == brand.ToUpper());
            }
            if (!string.IsNullOrEmpty(priceRange))
            {
                switch (priceRange)
                {
                    case "below5":
                        products = products.Where(p => p.UnitPrice < 5000000);
                        break;
                    case "5to10":
                        products = products.Where(p => p.UnitPrice >= 5000000 && p.UnitPrice <= 10000000);
                        break;
                    case "above10":
                        products = products.Where(p => p.UnitPrice > 10000000);
                        break;
                }


            }
            if (!string.IsNullOrEmpty(storage))
            {
                products = products.Where(p => p.ProductSpecification.StorageCapacity.Contains(storage));
            }
            if (!string.IsNullOrEmpty(sortOption))
            {
                switch (sortOption)
                {
                    case "a-z":
                        products = products.OrderBy(p => p.ProductName);
                        break;
                    case "z-a":
                        products = products.OrderByDescending(p => p.ProductName);
                        break;
                    case "price-asc":
                        products = products.OrderBy(p => p.UnitPrice);
                        break;
                    case "price-desc":
                        products = products.OrderByDescending(p => p.UnitPrice);
                        break;
                }
            }
            var pagedProducts = products.ToPagedList(pageNumber, pageSize);
            return View(pagedProducts);
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

        

        [HttpGet]
        public IActionResult Search(string query, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;
            var products = context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductSpecification)
                .Include(p => p.Warehouse)
                .AsQueryable();
            if (!string.IsNullOrEmpty(query))
            {
                query = query.ToLower().Trim();
                products = products.Where(p =>
           p.ProductName.ToLower().Contains(query) ||          // Tìm theo tên sản phẩm
           p.Description.ToLower().Contains(query) ||          // Tìm theo mô tả
           p.Brand.BrandName.ToLower().Contains(query) ||      // Tìm theo tên thương hiệu
           p.ProductSpecification.StorageCapacity.Contains(query) // Tìm theo dung lượng
       );
            }
            products = products.OrderBy(p => p.ProductName);


            var pagedProducts = products.ToPagedList(pageNumber, pageSize);

            return View("Search", pagedProducts);
        }
    }
}
