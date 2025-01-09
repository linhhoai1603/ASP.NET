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

        public List<Product> Products { get; set; }
    }
}
