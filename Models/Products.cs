using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("productId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "productId")]
        public int ProductId { get; set; }

        [Column("productName")]
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Column("unitPrice")]
        [Required(ErrorMessage = "Please enter the unit price.")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a positive value.")]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Column("description")]
        [Display(Name = "description")]
        public string? Description { get; set; }

        [Column("brandId")]
        [Required(ErrorMessage = "Please enter the brand id.")]
        [Display(Name = "brandId")]
        public int BrandId { get; set; }

        [Column("categoryId")]
        [Required(ErrorMessage = "Please enter the id category.")]
        [Display(Name = "categoryId")]
        public int CategoryId { get; set; }

        [Column("productSpecificationId")]
        [Required(ErrorMessage = "Please enter the product specification id.")]
        [Display(Name = "productSpecificationId")]
        public int ProductSpecificationId { get; set; }

        [Column("warehouseId")]
        [Required(ErrorMessage = "Please enter the warehouse id.")]
        [Display(Name = "warehouseId")]
        public int WarehouseId { get; set; }

        [Column("quantity")]
        [Required(ErrorMessage = "Please enter the quantity.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column("imgUrl")]
        [Required(ErrorMessage = "Please enter image url.")]
        [Display(Name = "imgUrl")]
        public string ImgUrl { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Color> Colors { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouses { get; set; }

        [ForeignKey("ProductSpecificationId")]
        public ProductSpecification ProductSpecification { get; set; }
        
    }
}
