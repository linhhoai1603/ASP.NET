using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class WarehouseVM
    {
        [Required(ErrorMessage = "Warehouse name is required")]
        [StringLength(100)]
        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; }
        [Required(ErrorMessage = "Address is not null.")]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
