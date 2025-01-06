using System.ComponentModel.DataAnnotations;
using Mysqlx.Crud;

namespace ProjectDotNET.Models
{
    public class OrderItems
    {
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Please enter your price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter your quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public double TotalPrice => Price * Quantity; // Tính toán giá trị totalPrice

        [Required(ErrorMessage = "Product id is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public Products Product { get; set; }

        [Required(ErrorMessage = "Order id is required")]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        public Orders Order { get; set; }

        public OrderItems(int orderItemId, double price, int quantity, Products product, Orders order)
        {
            OrderItemId = orderItemId;
            Price = price;
            Quantity = quantity;
            ProductId = product.product_id;
            OrderId = order.order_id;
            Product = product;
            Order = order;
        }

        public OrderItems() { }
    }
}
