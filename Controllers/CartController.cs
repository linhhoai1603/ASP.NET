using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using ProjectDotNET.Models;

public class CartController : Controller
{
    private readonly Shop_Context _context;

    public CartController(Shop_Context context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddToCart(int productId, int colorId, int quantity)
    {
        // Kiểm tra số lượng
        if (quantity <= 0)
        {
            TempData["Error"] = "Số lượng phải lớn hơn 0.";
            return RedirectToAction("Index", "Products");
        }

        // Lấy sản phẩm và màu sắc từ database
        var product = _context.Products
                              .Include(p => p.Colors)
                              .FirstOrDefault(p => p.ProductId == productId);

        if (product == null)
        {
            return NotFound();
        }

        var selectedColor = product.Colors.FirstOrDefault(c => c.ColorId == colorId);
        if (selectedColor == null)
        {
            TempData["Error"] = "Màu sắc không hợp lệ.";
            return RedirectToAction("Index", "Products");
        }

        // Lấy giỏ hàng từ Session
        var cartSession = HttpContext.Session.GetString("Cart");
        Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

        // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
        if (cart.Items.ContainsKey(colorId))
        {
            // Nếu có, tăng số lượng
            cart.Items[colorId].SetQuantity(cart.Items[colorId].Quantity + quantity);
        }
        else
        {
            // Thêm mới sản phẩm vào giỏ hàng
            CartItem newItem = new CartItem(selectedColor, quantity);
            cart.Items[colorId] = newItem;
        }

        // Lưu giỏ hàng vào Session
        HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));

        // Thông báo thành công
        TempData["Success"] = $"Đã thêm {product.ProductName} - {selectedColor.ColorName} ({quantity} sản phẩm) vào giỏ hàng.";

        // Chuyển hướng tới trang giỏ hàng
        return RedirectToAction("Cart");
    }

    // Hiển thị giỏ hàng
    public IActionResult Cart()
    {
        var cartSession = HttpContext.Session.GetString("Cart");
        Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);
        return View(cart);
    }

    // Cập nhật số lượng giỏ hàng
    [HttpPost]
    public IActionResult UpdateCart(int colorId, int quantity)
    {
        // Lấy giỏ hàng từ Session
        var cartSession = HttpContext.Session.GetString("Cart");
        Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

        if (cart.Items.ContainsKey(colorId))
        {
            cart.UpdateQuantity(colorId, quantity);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        return RedirectToAction("Cart");
    }

    // Xóa sản phẩm khỏi giỏ hàng
    [HttpPost]
    public IActionResult RemoveFromCart(int colorId)
    {
        // Lấy giỏ hàng từ Session
        var cartSession = HttpContext.Session.GetString("Cart");
        Cart cart = string.IsNullOrEmpty(cartSession) ? new Cart() : JsonConvert.DeserializeObject<Cart>(cartSession);

        if (cart.Items.ContainsKey(colorId))
        {
            cart.Remove(colorId);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        return RedirectToAction("Cart");
    }
}
