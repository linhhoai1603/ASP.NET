using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("products")]
    public class Products
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

        [Column("imgUrl")]
        [Required(ErrorMessage = "Please enter image url.")]
        [Display(Name = "imgUrl")]
        public string ImgUrl { get; set; }

        public Brands Brand { get; set; }
        public Categories Category { get; set; }
        public List<Colors> Colors { get; set; }
        public List<Order_Items> OrderItems { get; set; }
        public List<Warehouses> Warehouses { get; set; }
        public ProductSpecifications ProductSpecifications { get; set; }
    }
}
