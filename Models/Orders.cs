using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("orders")]
    public class Orders
    {
        [Key]
        [Column("orderId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "orderId")]
        public int OrderId { get; set; }

        [Column("orderDate")]
        [Required(ErrorMessage = "Please esnter the order date")]
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
        [Required(ErrorMessage = "user not null")]
        [Display(Name = "userId")]
        public int Userid { get; set; }

        public Users user { get; set; }
        public List<Order_Items> OrderItems { get; set; }
    }
}
