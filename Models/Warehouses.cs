using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Warehouses
    {
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "Warehouse name is required")]
        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public Products Product { get; set; }

        public Warehouses(int warehouseId, string warehouseName, string address, int quantity, Products product)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            Address = address;
            Quantity = quantity;
            ProductId = product.ProductId;
            Product = product;
        }

        public Warehouses() { }
    }
}
