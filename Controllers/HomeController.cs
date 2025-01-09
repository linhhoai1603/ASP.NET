using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using ProjectDotNET.Models;
using System.Diagnostics;

namespace ProjectDotNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Kiểm tra nếu session "Cart" đã tồn tại
            var cartSession = HttpContext.Session.GetString("Cart");

            // Nếu chưa có cart trong session, tạo mới một cart và set vào session
            if (string.IsNullOrEmpty(cartSession))
            {
                Cart cart = new Cart();

                // Serialize đối tượng Cart thành JSON và lưu vào session
                var serializedCart = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("Cart", serializedCart);
            }

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
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
