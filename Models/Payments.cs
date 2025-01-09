using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("paymentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Payment ID")]
        public int PaymentId { get; set; }

        [Column("amount")]
        [Required(ErrorMessage = "Please enter the amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        [Display(Name = "Amount")]
        public double Amount { get; set; }

        [Column("status")]
        [Required(ErrorMessage = "Please enter the payment status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Column("paymentDate")]
        [Required(ErrorMessage = "Please enter the payment date")]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Column("paymentMethod")]
        [Required(ErrorMessage = "Please select the payment method")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Column("orderId")]
        [Required(ErrorMessage = "Order ID is required")]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
