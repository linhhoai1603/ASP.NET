using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("warehouses")]
    public class Warehouse
    {
        [Key]
        [Column("warehouseId")]
        [Display(Name = "Warehouse Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }

        [Column("warehouseName")]
        [Required(ErrorMessage = "Warehouse name is required")]
        [StringLength(100)]
        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; }

        [Required(ErrorMessage = "Address is not null.")]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Column("quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column("productId")]
        [Required(ErrorMessage = "Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
