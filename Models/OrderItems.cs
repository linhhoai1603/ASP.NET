using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("orderItems")]
    public class OrderItem
    {
        [Key]
        [Column("orderItemId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order Item ID")]
        public int OrderItemId { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "Please enter the price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Column("quantity")]
        [Required(ErrorMessage = "Please enter the quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column("totalPrice")]
        [Display(Name = "Product ID")]
        public double TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
            set
            {}
        }

        [Column("productId")]
        [Required(ErrorMessage = "Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Column("orderId")]
        [Required(ErrorMessage = "Order ID is required")]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
