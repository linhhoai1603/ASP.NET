using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Please enter the order date")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Please select the payment method")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage = "Please enter the amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        [Display(Name = "Amount")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Please enter the payment status")]
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please enter the payment date")]
        [Display(Name = "Payment Date")]
        public string? PaymentDate { get; set; }

    }
}
