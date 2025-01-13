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
        [Display(Name = "Product ID")]
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

        [Column("lastPrice")]
        [Required(ErrorMessage = "Please enter the last price.")]
        [Range(0, double.MaxValue, ErrorMessage = "Last price must be a positive value.")]
        [Display(Name = "Last Price")]
        public double LastPrice { get; set; }

        [Column("description")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Column("brandId")]
        [Required(ErrorMessage = "Please enter the brand id.")]
        [Display(Name = "Brand ID")]
        public int BrandId { get; set; }

        [Column("categoryId")]
        [Required(ErrorMessage = "Please enter the category id.")]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Column("productSpecificationId")]
        [Required(ErrorMessage = "Please enter the product specification id.")]
        [Display(Name = "Product Specification ID")]
        public int ProductSpecificationId { get; set; }

        [Column("quantity")]
        [Required(ErrorMessage = "Please enter the quantity.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Column("imgUrl")]
        [Required(ErrorMessage = "Please enter the image URL.")]
        [Display(Name = "Image URL")]
        public string ImgUrl { get; set; }

        // ✅ Thêm WarehouseId
        [Column("warehouseId")]
        [Required(ErrorMessage = "Please enter the warehouse id.")]
        [Display(Name = "Warehouse ID")]
        public int WarehouseId { get; set; }

        // 🔗 Liên kết với bảng Brand
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        // 🔗 Liên kết với bảng Category
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        // 🔗 Liên kết với bảng ProductSpecification
        [ForeignKey("ProductSpecificationId")]
        public ProductSpecification ProductSpecification { get; set; }

        // 🔗 Liên kết với bảng Warehouse
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        // 🔗 Danh sách màu sắc sản phẩm
        public List<Color> Colors { get; set; }
    }
}
