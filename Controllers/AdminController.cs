

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using ProjectDotNET.ViewModels;


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

        //    var users = _context.Users.ToList();  // Lấy danh sách người dùng từ cơ sở dữ liệu
        //    return View(users);
        //}
        // Hiển thị danh sách người dùng và form thêm, chỉnh sửa
  
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
        //[HttpGet]
        //public IActionResult AddUser()
        //{
        //    return View("ManagerUser");
        //}
        //[HttpPost]
        //public IActionResult AddUser(UserVM user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (_context.Users.Any(u => u.Phone == user.Phone))
        //            {
        //                ModelState.AddModelError("Phone", "Phone number already exists.");
        //                return RedirectToAction("ManagerUser");
        //            }
        //            if (_context.Users.Any(u => u.Email == user.Email))
        //            {
        //                ModelState.AddModelError("Email", "Email already exists.");
        //                return RedirectToAction("ManagerUser");
        //            }

        //            var newUser = new User
        //            {
        //                Username = user.Username,
        //                Password = new PasswordHasher<UserVM>().HashPassword(user, user.Password), // Mã hóa mật khẩu
        //                Role = user.Role,
        //                Address = user.Address,
        //                Phone = user.Phone,
        //                Email = user.Email,
        //                FullName = user.FullName
        //            };

        //            _context.Users.Add(newUser);
        //            _context.SaveChanges();

        //            TempData["SuccessMessage"] = "Registration successful!";
        //            //return RedirectToAction("ManagerUser");
        //        }
        //        catch (Exception ex)
        //        {
        //            TempData["ErrorMessage"] = "An error occurred during registration.";
        //            //return View("ManagerUser", user);
        //        }

        //    }
        //    return RedirectToAction("ManagerUser", "Admin");
        //}
        //[HttpGet]
        //public IActionResult EditUser(int id)
        //{
        //    var user = _context.GetUserById(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Chuyển UserModel sang UserViewModel
        //    var userViewModel = new UserVM
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        Phone = user.Phone,
        //        Email = user.Email,
        //        Address = user.Address,
        //        FullName = user.FullName,
        //        Password = user.Password,  // Nếu cần mã hóa mật khẩu, bạn có thể bỏ qua trong ViewModel
        //        Role = user.Role
        //    };

        //    return View("ManagerUser", userViewModel);
        //}

        //[HttpPost]
        //public IActionResult EditUser(UserVM viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _context.UpdateUser(viewModel);
        //        if (result)
        //        {
        //            return RedirectToAction("ManagerUser");
        //        }
        //        ModelState.AddModelError("", "Không thể cập nhật người dùng.");
        //    }
        //    return View(viewModel);
        //}
        //[HttpPost("DeleteUser/{userId}")]
        //public IActionResult DeleteUser(int userId)
        //{
        //    var user = _context.Users.Find(userId);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //        _context.SaveChanges();
        //        TempData["SuccessMessage"] = "User deleted successfully!";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "User not found.";
        //    }
        //    return RedirectToAction("ManagerUser", "Admin");  // Quay lại trang quản lý người dùng
        //}
        // Thêm người dùng
       
        
       
    }
}
