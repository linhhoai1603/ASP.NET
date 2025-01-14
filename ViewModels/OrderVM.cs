using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class OrderVM
    {
        [Required(ErrorMessage = "Please enter the order id")]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter the order date")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Please enter the total amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }
        [Required(ErrorMessage = "Please enter the order status")]
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string UserName { get; set; } // User Model
        [Required(ErrorMessage = "Payment ID cannot be null")]
        [Display(Name = "Payment ID")]
        public string PaymentMethod { get; set; }// Payment
        [Required(ErrorMessage = "At least one product must be added to the order.")]
        [MinLength(1, ErrorMessage = "At least one product must be selected.")]
        [Display(Name = "Order Items")]
        public List<OrderItemsVM> OrderItems { get; set; } // OrderItems
    }
}
