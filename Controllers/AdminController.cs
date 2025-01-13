using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;

namespace ProjectDotNET.Controllers
{
    public class AdminController : Controller
    {
        private readonly Shop_Context context;
        public AdminController(Shop_Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Tính doanh thu theo tháng
            var monthlyRevenue = context.Orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Month = $"{g.Key.Month}-{g.Key.Year}",
                    Revenue = g.Sum(o => o.TotalAmount)
                })
                .ToList();

            // Lấy dữ liệu doanh thu và tháng
            var revenueData = monthlyRevenue.Select(m => m.Revenue).ToList();
            var months = monthlyRevenue.Select(m => m.Month).ToList();

            // Truyền dữ liệu doanh thu và tháng vào ViewBag
            ViewBag.Revenue = revenueData;
            ViewBag.MonthlyRevenue = months;

            // Lấy 5 đơn hàng gần đây
            var recentOrders = context.Orders
                .Include(o => o.User) // Đảm bảo User được nạp (eager loading)
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToList();

            ViewBag.RecentOrders = recentOrders;

            return View();
        }
        //[HttpGet]
        //public IActionResult ManagerUser()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult ManagerMessage()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult ManagerOrder()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult ManagerPayment()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult ManagerProduct()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        // GET: View Product
        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return Json(new { success = false });
            }

            return Json(new { success = true, product });
        }

        // POST: Edit Product
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // POST: Add Product
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // POST: Delete Product
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            context.Products.Remove(product);
            context.SaveChanges();
            return Json(new { success = true });
        }


        // --- Manage Warehouses ---

        // GET: Manager Warehouses
        [HttpGet]
        public IActionResult ManagerWareHouse()
        {
            var warehouses = context.Warehouses.ToList();
            return View(warehouses);
        }

        // GET: View Warehouse
        [HttpGet]
        public IActionResult ViewWarehouse(int warehouseId)
        {
            var warehouse = context.Warehouses
                .Include(w => w.Products)  // Include products if you need to show them as well
                .FirstOrDefault(w => w.WarehouseId == warehouseId);

            if (warehouse == null)
            {
                return Json(new { success = false });
            }

            return Json(new { success = true, warehouse });
        }
        // POST: Edit Warehouse
        [HttpPost]
        public IActionResult EditWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                var existingWarehouse = context.Warehouses
                    .FirstOrDefault(w => w.WarehouseId == warehouse.WarehouseId);

                if (existingWarehouse != null)
                {
                    existingWarehouse.WarehouseName = warehouse.WarehouseName;
                    existingWarehouse.Address = warehouse.Address;
                    // Update other fields as necessary
                    context.SaveChanges();
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        // POST: Add Warehouse
        [HttpPost]
        public IActionResult AddWarehouse(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // POST: Delete Warehouse
        [HttpPost]
        public IActionResult DeleteWarehouse(int warehouseId)
        {
            var warehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseId == warehouseId);
            if (warehouse != null)
            {
                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
