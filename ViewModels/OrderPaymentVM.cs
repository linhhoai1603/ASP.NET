using System;
using System.Collections.Generic;
using Models;
using ProjectDotNET.Models;

namespace ProjectDotNET.ViewModels
{
    public class OrderPaymentVM
    {
        // Thông tin khách hàng
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Thông tin đơn hàng
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string DeliveryMethod { get; set; }

        // Danh sách sản phẩm trong giỏ hàng
        public List<CartItem> CartItems { get; set; }
    }
}
