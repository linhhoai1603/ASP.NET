using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;
using ProjectDotNET.ViewModels;

namespace ProjectDotNET.Controllers
{
    public class OrderedController : Controller
    {
        private readonly Shop_Context context;

        public OrderedController(Shop_Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ordered()
        {
            // Kiểm tra nếu người dùng đã đăng nhập
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để xem lịch sử đơn hàng.";
                return RedirectToAction("Login", "Home");
            }

            // Lấy các đơn hàng và các item liên quan đến đơn hàng của người dùng từ cơ sở dữ liệu
            var orders = context.Orders
                                 .Where(o => o.UserId == userId)
                                 .Include(o => o.OrderItems)
                                     .ThenInclude(oi => oi.Product)  // Nạp thông tin sản phẩm từ OrderItems
                                 .ToList();

            // Kiểm tra nếu không có đơn hàng
            if (orders.Count == 0)
            {
                TempData["ErrorMessage"] = "Không có đơn hàng nào.";
                return View();
            }

            // Lọc ra danh sách các đơn hàng với thông tin chi tiết
            var orderVMs = orders.Select(o => new OrderVM
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                Status = o.Status,
                TotalAmount = o.TotalAmount,
                OrderItems = o.OrderItems.Select(oi => new OrderItemsVM
                {
                    ProductName = oi.Product.ProductName,
                    ProductImgUrl = oi.Product.ImgUrl,
                    Quantity = oi.Quantity,
                    Price = oi.Price,
                    TotalPrice = oi.TotalPrice
                }).ToList()
            }).ToList();

            // Tính tổng giá trị đơn hàng
            ViewData["TotalOrderValue"] = orderVMs.Sum(o => o.TotalAmount);

            // Trả về view với danh sách các đơn hàng đã chuyển thành ViewModel
            return View(orderVMs);
        }
    }
}
