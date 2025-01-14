using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDotNET.Models;


namespace ProjectDotNET.Controllers
{
    public class ContactController : Controller
    {
        private readonly Shop_Context _context;
        public ContactController(Shop_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
            public ActionResult Contact()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // 1. Lưu thông tin liên hệ vào cơ sở dữ liệu
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();
       
                    // 2. Điều hướng đến trang xác nhận hoặc trang chính
                    TempData["SuccessMessage"] = "Gửi tin nhắn thành công, vui lòng đợi nhận viên liên hệ.";
                    return RedirectToAction("Contact");
                }
                catch (Exception ex)
                {

                    // Hiển thị thông báo lỗi đến người dùng
                    TempData["ErrorMessage"] = "Thông điệp của bạn chưa được gửi đi, vui lòng thử lại.";
                    return View(contact);
                }
            }

            // Trường hợp không hợp lệ, trả lại form với lỗi
            return View(contact);
        }

    }
}
