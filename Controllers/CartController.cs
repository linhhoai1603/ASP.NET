using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace ProjectDotNET.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cart()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddToCart(int productId, int quantity)
        {
            // Lấy giỏ hàng từ session
            var cartSession = HttpContext.Session.GetString("Cart");
            Cart cart;

            if (string.IsNullOrEmpty(cartSession))
            {
                cart = new Cart();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartSession);
            }

            // Giả sử bạn đã có phương thức GetProductById để lấy sản phẩm từ cơ sở dữ liệu
            var product = GetProductById(productId);

            // Thêm sản phẩm vào giỏ hàng
            var cartItem = new CartItem(product, quantity);
            cart.Add(cartItem);

            // Serialize lại giỏ hàng và lưu vào session
            var serializedCart = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("Cart", serializedCart);

            return RedirectToAction("Index"); // Điều hướng đến trang giỏ hàng
        }

    }
}
