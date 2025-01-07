using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mysqlx.Crud;

namespace ProjectDotNET.Models
{
    [Table("orderItems")]
    public class Order_Items
    {
        [Key]
        [Column("orderItemId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "order items id")]
        public int OrderItemId { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "Please enter your price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Column("quantity")]
        [Required(ErrorMessage = "Please enter your quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public double TotalPrice => Price * Quantity; // Tính toán giá trị totalPrice

        [Column("productId")]
        [Required(ErrorMessage = "Product id is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Column("orderId")]
        [Required(ErrorMessage = "Order id is required")]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }

    }
}
