using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("payments")]
    public class Payments
    {
        [Key]
        [Column("paymentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "paymentId")]
        public int PaymentId { get; set; }

        [Column("amount")]
        [Required(ErrorMessage = "Please enter the amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        [Display(Name = "amount")]
        public double Amount { get; set; }

        [Column("status")]
        [Required(ErrorMessage = "Please enter the payment status")]
        [Display(Name = "status")]
        public string Status { get; set; }

        [Column("paymentDate")]
        [Required(ErrorMessage = "Please enter the payment date")]
        [Display(Name = "paymentDate")]
        public DateTime PaymentDate { get; set; }

        [Column("paymentMethod")]
        [Required(ErrorMessage = "Please select the payment method")]
        [Display(Name = "paymentMethod")]
        public string PaymentMethod { get; set; }

        [Column("orderId")]
        [Required(ErrorMessage = "Order ID is required")]
        [Display(Name = "orderId")]
        public int OrderId { get; set; }

        public Orders Orders { get; set; }
    }
}
