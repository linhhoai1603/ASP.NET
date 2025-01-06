using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Please enter the amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Please enter the payment status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter the payment date")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Please select the payment method")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Order ID is required")]
        public int OrderId { get; set; }

        public Orders Orders { get; set; }

        public Payments(int paymentId, double amount, string status, DateTime paymentDate, string paymentMethod, Orders orders)
        {
            PaymentId = paymentId;
            Amount = amount;
            Status = status;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            OrderId = orders.OrderId;
            Orders = orders;
        }

        public Payments() { }
    }
}
