

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using ProjectDotNET.ViewModels;
using System;
using System.Linq;


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
            try
            {
                // Tính doanh thu theo tháng
                var monthlyRevenue = context.Orders
                    .Where(o => o.OrderDate != null) // Đảm bảo OrderDate không null
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

                // Lấy 5 đơn hàng gần đây
               

                // Truyền dữ liệu vào ViewBag
                ViewBag.Revenue = revenueData ?? new List<double>();
                ViewBag.MonthlyRevenue = months ?? new List<string>();
                


                return View();
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                ViewBag.ErrorMessage = "An error occurred while loading the dashboard.";
                return View();
            }

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

        public IActionResult ManagerUser(int? id)
        {
            if (id.HasValue)
            {
                // Nếu có id, trả về thông tin người dùng để chỉnh sửa
                var user = context.Users.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    return View(user);  // Trả về view cùng dữ liệu user cần chỉnh sửa
                }
            }

            var users = context.Users.ToList();
            return View(users);  // Trả về tất cả người dùng
        }
     
        [HttpGet]
        public IActionResult ManagerOrder()
        {
            var orders = context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult ViewOrder(int id)
        {
            var order = context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                TempData["ErrorMessage"] = "Order not found.";
                return RedirectToAction("ManagerOrder");
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Order added successfully!";
                return RedirectToAction("ManagerOrder");
            }

            TempData["ErrorMessage"] = "Error adding order.";
            return RedirectToAction("ManagerOrder");
        }
        [HttpPost]
        public IActionResult DeleteOrder(int orderId)
        {
            // Tìm Order và bao gồm OrderItems
            var order = context.Orders
                                .Include(o => o.OrderItems) // Bao gồm các OrderItems
                                .FirstOrDefault(o => o.OrderId == orderId);

            // Kiểm tra nếu không tìm thấy Order
            if (order == null)
            {
                return Json(new { success = false, message = "Order not found." });
            }

            // Xóa OrderItems trước nếu có
            if (order.OrderItems != null && order.OrderItems.Count > 0)
            {
                context.Order_Items.RemoveRange(order.OrderItems);
            }

            // Xóa Order
            context.Orders.Remove(order);
            context.SaveChanges();

            return Json(new { success = true });
        }



        [HttpGet]
        public IActionResult ManagerPayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManagerProduct()
        {
            var products = context.Products.ToList();
            return View(products);
        }



        [HttpGet]
        public IActionResult ViewProduct(int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            return Json(new { success = true, product });
        }


        // Chỉnh sửa sản phẩm
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            var existingProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
            {
                return Json(new { success = false, message = "Product not found." });
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.Description = product.Description;
            existingProduct.BrandId = product.BrandId;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.ImgUrl = product.ImgUrl;

            context.SaveChanges();
            return Json(new { success = true, message = "Product updated successfully!" });
        }


        // Thêm sản phẩm
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Json(new { success = true, message = "Product added successfully!" });
            }

            return Json(new { success = false, message = "Failed to add product." });
        }


        // Xóa sản phẩm
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var product = context.Products.Find(productId);  // Tìm sản phẩm trong cơ sở dữ liệu
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found." });
                }

                context.Products.Remove(product);  // Xóa sản phẩm
                context.SaveChanges();  // Lưu thay đổi

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [HttpGet]
        public IActionResult ManagerWareHouse()
        {
            var warehouses = context.Warehouses
                .Include(w => w.Products)
                .ToList();
            return View(warehouses);
        }

        [HttpGet]
        public IActionResult ViewWarehouse(int warehouseId)
        {
            var warehouse = context.Warehouses
                .Include(w => w.Products)
                .FirstOrDefault(w => w.WarehouseId == warehouseId);

            if (warehouse == null)
            {
                return Json(new { success = false, message = "Warehouse not found." });
            }

            return Json(new
            {
                success = true,
                warehouse = new
                {
                    warehouse.WarehouseId,
                    warehouse.WarehouseName,
                    warehouse.Address,
                    Products = warehouse.Products.Select(p => new { p.ProductId }).ToList()
                }
            });
        }

        [HttpPost]
        public IActionResult AddWarehouse([FromForm] Warehouse warehouse)
        {
            if (string.IsNullOrEmpty(warehouse.WarehouseName) || string.IsNullOrEmpty(warehouse.Address))
            {
                return Json(new { success = false, message = "Invalid data." });
            }

            context.Warehouses.Add(warehouse);
            context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult EditWarehouse([FromForm] Warehouse warehouse)
        {
            var existingWarehouse = context.Warehouses.FirstOrDefault(w => w.WarehouseId == warehouse.WarehouseId);
            if (existingWarehouse == null)
            {
                return Json(new { success = false, message = "Warehouse not found." });
            }

            existingWarehouse.WarehouseName = warehouse.WarehouseName;
            existingWarehouse.Address = warehouse.Address;
            context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult DeleteWarehouse(int warehouseId)
        {
            var warehouse = context.Warehouses
                .Include(w => w.Products)
                .FirstOrDefault(w => w.WarehouseId == warehouseId);

            if (warehouse == null)
            {
                return Json(new { success = false, message = "Warehouse not found." });
            }

            context.Products.RemoveRange(warehouse.Products);
            context.Warehouses.Remove(warehouse);
            context.SaveChanges();

            return Json(new { success = true });
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


        [HttpPost]
        public IActionResult AddUser(UserVM user)
        {
            {
                var newUser = new User
                {
                    Username = user.Username,
                    Password = new PasswordHasher<UserVM>().HashPassword(user, user.Password),
                    Phone = user.Phone,
                    Email = user.Email,
                    FullName = user.FullName,
                    Address = user.Address,
                    Role = user.Role
                };

                context.Users.Add(newUser);
                context.SaveChanges();
                TempData["SuccessMessage"] = "User added successfully!";
                return RedirectToAction("ManagerUser");
            }

            TempData["ErrorMessage"] = "Error adding user.";
            return RedirectToAction("ManagerUser");
        }
        

        // Chỉnh sửa người dùng
        [HttpPost]
        public IActionResult EditUser(UserVM user)
        {
            var existingUser = context.Users.FirstOrDefault(u => u.UserId == user.Id);
            if (existingUser == null)
            {
                TempData["SuccessMessage"] = $"User not found with ID: {user.Id}";
            }
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Phone = user.Phone;
                existingUser.Email = user.Email;
                existingUser.FullName = user.FullName;
                existingUser.Address = user.Address;
                existingUser.Role = user.Role;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.Password = new PasswordHasher<UserVM>().HashPassword(user, user.Password);
                }
                context.SaveChanges();
                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToAction("ManagerUser");
            }
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("ManagerUser");
        }

        // Xóa người dùng
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                TempData["SuccessMessage"] = "User deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "User not found.";
            }

            return RedirectToAction("ManagerUser");
        }

        //  Phần quản lý payment
        
        // sửa thông tin thanh toán
        [HttpPost]
        public IActionResult EditPayment(Payment payment)
        {
            try
            {
                var existingPayment = context.Payments.FirstOrDefault(p => p.PaymentId == payment.PaymentId);
                if (existingPayment != null)
                {
                    // Cập nhật các trường thông tin payment
                    existingPayment.OrderId = payment.OrderId;
                    existingPayment.Amount = payment.Amount;
                    existingPayment.Status = payment.Status;
                    existingPayment.PaymentDate = payment.PaymentDate;
                    existingPayment.PaymentMethod = payment.PaymentMethod;

                    context.SaveChanges();
                    TempData["SuccessMessage"] = "Payment updated successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Payment not found.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating payment: {ex.Message}";
            }

            return RedirectToAction("ManagerPayment");
        }
        // xóa thông tin thanh toán
        [HttpPost]
        public IActionResult DeletePayment(int IdPayment)
        {
            try
            {
                // Tìm payment cần xóa theo Id
                var payment = context.Payments.FirstOrDefault(p => p.PaymentId == IdPayment);
                if (payment == null)
                {
                    TempData["ErrorMessage"] = "Payment not found.";
                    return RedirectToAction("ManagerPayment");
                }

                // Xóa payment
                context.Payments.Remove(payment);

                // Lưu thay đổi vào cơ sở dữ liệu
                context.SaveChanges();

                // Thông báo thành công
                TempData["SuccessMessage"] = "Payment deleted successfully.";
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, thông báo lỗi
                TempData["ErrorMessage"] = $"Error deleting payment: {ex.Message}";
            }

            return RedirectToAction("ManagerPayment");
        }
        // method add payment
        [HttpPost]
        public IActionResult AddPayment(Payment payment)
        {
            try
            {
                // Thêm payment mới vào cơ sở dữ liệu
                context.Payments.Add(payment);
                context.SaveChanges();

                // Thông báo thành công
                TempData["SuccessMessage"] = "Payment added successfully.";
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, thông báo lỗi
                TempData["ErrorMessage"] = $"Error adding payment: {ex.Message}";
            }

            return RedirectToAction("ManagerPayment");
        }
        [HttpGet]
        public IActionResult ManagerMessage()
        {
            var contacts = context.Contacts.ToList();
            return View(contacts);
        }
        // Phương thức để thêm tin nhắn mới (nếu cần)
        [HttpPost]
        public IActionResult AddMessage(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
                return RedirectToAction("ManagerMessage");
            }
            return View(contact);
        }

        // Phương thức để xóa tin nhắn
        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
            var contact = context.Contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                context.SaveChanges();
                TempData["Message"] = "Message deleted successfully!";  // Thông báo thành công
            }
            else
            {
                TempData["Message"] = "Message not found!";  // Thông báo thất bại
            }

            return RedirectToAction("ManagerMessage");  // Quay lại trang quản lý
        }



    }
}


