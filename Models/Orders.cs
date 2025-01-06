using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please esnter the order date")]
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }

        [Required(ErrorMessage = "Please enter the total amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Required(ErrorMessage = "Please enter the order status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public List<OrderItems> OrderItems { get; set; }

        public Orders(int orderId, string orderDate, double totalAmount, string status)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
            OrderItems = new List<OrderItems>();
        }

        public Orders()
        {
            OrderItems = new List<OrderItems>(); // Khởi tạo danh sách OrderItems trong constructor mặc định
        }
    }
}
