using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using ProjectDotNET.Models;
namespace ProjectDotNET.Helper;
using ViewModels;


public class CartController : Controller
{
    private readonly Shop_Context _context;

    public CartController(Shop_Context context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Cart()
    {
        var cart = CartGet;
        return View(cart);
    }
    public List<CartItem> CartGet
    {
        get
        {
            var data = HttpContext.Session.Get<List<CartItem>>("Cart");
            if (data == null)
            {
                data = new List<CartItem>();
            }
            return data;
        }
    }
    [HttpPost]
    public IActionResult AddToCart(int productID, int quantity)
    {
        var myCart = CartGet; // Giỏ hàng hiện tại (giả sử đây là danh sách giỏ hàng)

        // Kiểm tra xem sản phẩm đã có trong giỏ hàng hay chưa
        var item = myCart.FirstOrDefault(p => p.ProductId == productID);

        if (item != null)
        {
            item.Quantity += quantity;

        }
        else
        {
            // Nếu sản phẩm chưa có trong giỏ, lấy thông tin sản phẩm từ cơ sở dữ liệu
            var product = _context.Products
                .Include(p => p.Brand)  // Bao gồm thông tin thương hiệu sản phẩm
                .FirstOrDefault(p => p.ProductId == productID);  // Lấy sản phẩm theo productID

            if (product == null)
            {
                // Nếu không tìm thấy sản phẩm, trả về lỗi
                return NotFound("Sản phẩm không tồn tại.");
            }

            // Tạo một CartItem mới với thông tin sản phẩm
            var newItem = new CartItem
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Image = product.ImgUrl,
                Quantity = quantity,
                UnitPrice = product.UnitPrice
            };

            // Thêm sản phẩm vào giỏ hàng
            myCart.Add(newItem);
        }

        // Lưu giỏ hàng vào session
        HttpContext.Session.Set("Cart", myCart);

        // Trả về kết quả hoặc điều hướng (redirect) tới trang giỏ hàng
        return RedirectToAction("Products", "Products");
    }
    [HttpPost]
    public IActionResult UpdateQuantity(int productId, int quantity)
    {
        var cart = CartGet;
        if (cart == null)
        {
            return RedirectToAction("Index", "Home");
        }
        var item = cart.FirstOrDefault(p => p.ProductId == productId);
        if (item == null)
        {
            return RedirectToAction("Index", "Home");
        }
        item.Quantity = quantity;
        HttpContext.Session.Set("Cart", cart);
        return RedirectToAction("Cart", "Cart");
    }
    [HttpPost]
    public IActionResult RemoveItem(int productId)
    {
        var cart = CartGet;
        if (cart == null)
        {
            return RedirectToAction("Index", "Home");
        }
        var item = cart.FirstOrDefault(p => p.ProductId == productId);
        if (item != null)
        {
            cart.Remove(item);
        }
        HttpContext.Session.Set("Cart", cart);
        return RedirectToAction("Cart", "Cart");
    }
    [HttpGet]
    public IActionResult Payment()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
       
        if (userId == null)
        {
            TempData["ErrorMessage"] = "Bạn cần đăng nhập để thanh toán.";
            return RedirectToAction("Login", "Home");
        }
        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        var cart = CartGet;

        var payment = new PaymentVM
        {
            FullName = user.FullName,
            Phone = user.Phone,
            Email = user.Email,
            Address = user.Address,
            OrderDate = DateTime.Now,
            TotalAmount = cart.Sum(p => p.UnitPrice * p.Quantity),
            Status = "Đang chờ xử lý",
            cartItems = cart
        };
        

        return View(payment);
    }


}
