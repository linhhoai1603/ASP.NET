using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Models;
using Newtonsoft.Json;
using ProjectDotNET.Models;
using ProjectDotNET.ViewModels;
using System.Diagnostics;

namespace ProjectDotNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly Shop_Context _context;

        public HomeController(Shop_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Key: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                TempData["ErrorMessage"] = "Thông tin đăng nhập không hợp lệ.";
                return View(login);
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Phone == login.Phone);
            if (existingUser == null)
            {
                Console.WriteLine($"Không tìm thấy user với số điện thoại: {login.Phone}");
                TempData["ErrorMessage"] = "Số điện thoại không tồn tại.";
                return View(login);
            }
            var passwordHasher = new PasswordHasher<LoginVM>();
            var result = passwordHasher.VerifyHashedPassword(login, existingUser.Password, login.Password);

            if (result == PasswordVerificationResult.Success)
            {
                Console.WriteLine("Mật khẩu khớp.");
                // Đăng nhập thành công
                HttpContext.Session.SetInt32("UserId", existingUser.UserId);
                HttpContext.Session.SetString("Username", existingUser.Username);
                HttpContext.Session.SetInt32("Role", existingUser.Role);
                if (existingUser.Role == 1)
                {
                    TempData["SuccessMessage"] = "Đăng nhập thành công với quyền Admin!";
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    TempData["SuccessMessage"] = "Đăng nhập thành công với quyền User!";
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                Console.WriteLine($"Kết quả xác minh mật khẩu: {result}");
                TempData["ErrorMessage"] = "Sai mật khẩu.";
                return View(login);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Kiểm tra xem email và phone đã tồn tại trong hệ thống chưa
                    if (_context.Users.Any(u => u.Phone == user.Phone))
                    {
                        ModelState.AddModelError("Phone", "Phone number already exists.");
                        return View(user);
                    }
                    if (_context.Users.Any(u => u.Email == user.Email))
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        return View(user);
                    }

                    // Ánh xạ từ UserVM sang User Entity
                    var newUser = new User
                    {
                        Username = user.Username,
                        Password = new PasswordHasher<UserVM>().HashPassword(user, user.Password), // Mã hóa mật khẩu
                        Role = user.Role,
                        Address = user.Address,
                        Phone = user.Phone,
                        Email = user.Email,
                        FullName = user.FullName
                    };

                    // Thêm vào cơ sở dữ liệu
                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    // Log lỗi và trả về trang đăng ký
                    TempData["ErrorMessage"] = "An error occurred during registration.";
                    return View(user);
                }
            }

            // Nếu ModelState không hợp lệ, quay lại trang đăng ký
            return View(user);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            // Kiểm tra nếu người dùng đã đăng nhập
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để xem thông tin cá nhân.";
                return RedirectToAction("Login", "Home");
            }

            // Lấy thông tin user từ database
            var user = _context.Users
                .Where(u => u.UserId == userId)
                .Select(u => new UserVM
                {
                    Username = u.Username,
                    Email = u.Email,
                    Phone = u.Phone,
                    Address = u.Address,
                    FullName = u.FullName,
                    Role = u.Role
                })
                .FirstOrDefault();

            if (user == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy thông tin người dùng.";
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }
    }
}