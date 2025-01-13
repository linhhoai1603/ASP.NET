using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using ProjectDotNET.ViewModels;

namespace ProjectDotNET.Controllers
{
    public class AdminController : Controller
    {
        Shop_Context _context;
        public AdminController(Shop_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            ViewData["UserCount"] = _context.Users.Count();
            ViewData["OrderCount"] = _context.Orders.Count();
            ViewData["ProductCount"] = _context.Products.Count();
            return View();
        }
        //[HttpGet]
        //public IActionResult ManagerUser()
        //{
        //    var users = _context.Users.ToList();  // Lấy danh sách người dùng từ cơ sở dữ liệu
        //    return View(users);
        //}
        // Hiển thị danh sách người dùng và form thêm, chỉnh sửa
        public IActionResult ManagerUser(int? id)
        {
            if (id.HasValue)
            {
                // Nếu có id, trả về thông tin người dùng để chỉnh sửa
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    return View(user);  // Trả về view cùng dữ liệu user cần chỉnh sửa
                }
            }

            var users = _context.Users.ToList();
            return View(users);  // Trả về tất cả người dùng
        }
        [HttpGet]
        public IActionResult ManagerMessage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerOrder()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerPayment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerProduct()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManagerWareHouse()
        {
            return View();
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
            if (ModelState.IsValid)
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

                _context.Users.Add(newUser);
                _context.SaveChanges();
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
            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.Id);
            if(existingUser == null)
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
                _context.SaveChanges();
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
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "User not found.";
            }

            return RedirectToAction("ManagerUser");
        }
    }
}
