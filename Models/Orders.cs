using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("orderId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Column("orderDate")]
        [Required(ErrorMessage = "Please enter the order date")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Column("totalAmount")]
        [Required(ErrorMessage = "Please enter the total amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Column("status")]
        [Required(ErrorMessage = "Please enter the order status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Column("userId")]
        [Required(ErrorMessage = "User ID cannot be null")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
