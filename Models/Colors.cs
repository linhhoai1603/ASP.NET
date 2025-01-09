using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("colors")]
    public class Color
    {
        [Key]
        [Column("colorId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Color ID")]
        public int ColorId { get; set; }

        [Column("colorName")]
        [Required(ErrorMessage = "Color name is required")]
        [Display(Name = "Color Name")]
        [StringLength(50)]
        public string ColorName { get; set; }

        [Column("colorImg")]
        [Required(ErrorMessage = "Color image is required")]
        [StringLength(200)]
        public string ColorImg { get; set; }

        [Column("productId")]
        [Required(ErrorMessage = "Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Color(int colorId, string colorName, string colorImg, Product product)
        {
            this.ColorId = colorId;
            this.ColorName = colorName;
            this.ColorImg = colorImg;
            this.Product = product;
            this.ProductId = product.ProductId;
        }

        public Color()
        {
        }
    }
}
