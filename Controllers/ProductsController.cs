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

    }
}
