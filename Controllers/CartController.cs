using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using ProjectDotNET.Models;

namespace ProjectDotNET.Controllers
{
   public class CartController : Controller
    {
        private readonly Shop_Context _context;

        // Constructor để nhận Shop_Context từ DI container
        public CartController(Shop_Context context)
        {
            _context = context;  // Gán giá trị context vào biến _context
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cart(int idColor, int quantity)
        {
            // Lấy giỏ hàng từ session
            var cartSession = HttpContext.Session.GetString("Cart");

            // Nếu giỏ hàng chưa tồn tại trong session, tạo mới một giỏ hàng trống
            Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

            // Gửi giỏ hàng tới view
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToCart(int idColor, int quantity)
        {
            // Lấy giỏ hàng từ session
            var cartSession = HttpContext.Session.GetString("Cart");

            // Nếu giỏ hàng chưa tồn tại trong session, tạo mới một giỏ hàng trống
            Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

            // Lấy thông tin màu sắc từ database sử dụng Entity Framework
            var color = _context.Colors.FirstOrDefault(c => c.ColorId == idColor);

            // Kiểm tra nếu màu sắc không tồn tại
            if (color == null)
            {
                return NotFound(); // Hoặc trả về một thông báo lỗi thích hợp
            }

            // Tạo một CartItem mới
            CartItem item = new CartItem(color, quantity);

            // Thêm CartItem vào giỏ hàng
            cart.Add(item);

            // Lưu giỏ hàng vào session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));

            // Chuyển hướng tới trang giỏ hàng
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int idColor, int quantity)
        {
            // Lấy giỏ hàng từ session
            var cartSession = HttpContext.Session.GetString("Cart");

            // Nếu giỏ hàng chưa tồn tại trong session, tạo mới một giỏ hàng trống
            Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

            // Kiểm tra nếu sản phẩm trong giỏ hàng tồn tại
            if (cart.Items.ContainsKey(idColor))
            {
                // Cập nhật số lượng của sản phẩm
                cart.UpdateQuantity(idColor, quantity);
            }
            else
            {
                return NotFound(); // Sản phẩm không tồn tại trong giỏ hàng
            }

            // Lưu giỏ hàng vào session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));

            // Chuyển hướng lại đến trang giỏ hàng
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult RemoveItem(int idColor)
        {
            // Lấy giỏ hàng từ session
            var cartSession = HttpContext.Session.GetString("Cart");

            // Nếu giỏ hàng chưa tồn tại trong session, tạo mới một giỏ hàng trống
            Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

            // Kiểm tra nếu sản phẩm trong giỏ hàng tồn tại
            if (cart.Items.ContainsKey(idColor))
            {
                // Xóa sản phẩm khỏi giỏ hàng
                cart.Remove(idColor);
            }
            else
            {
                return NotFound(); // Sản phẩm không tồn tại trong giỏ hàng
            }

            // Lưu giỏ hàng vào session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));

            // Chuyển hướng lại đến trang giỏ hàng
            return RedirectToAction("Cart");
        }


    }
}
