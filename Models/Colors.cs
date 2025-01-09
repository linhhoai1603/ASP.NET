using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("colors")]
    public class Colors
    {
        [Key]
        [Column("colorId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Color ID")]
        public int color_id { get; set; }

        [Column("colorName")]
        [Required(ErrorMessage = "Color name is required")]
        [Display(Name = "Color Name")]
        [StringLength(50)]
        public String color_name { get; set; }

        [Column("colorImg")]
        [Required(ErrorMessage = "Color image is required")]
        [StringLength(200)]
        public String color_img { get; set; }

        [Column("productId")]
        [Required(ErrorMessage = "Product id is required")]
        [Display(Name ="Product ID")]
        public int product_id { get; set; }
      public Products Products { get; set; }
        public Colors(int color_id, String color_name, String color_img, Products Products)
        {
            this.color_id = color_id;
            this.color_name = color_name;
            this.color_img = color_img;
            this.Products = Products;
            this.product_id = Products.ProductId;
        }
        public Colors()
        {
        }

        public List<Products> Products { get; set; }   }
}
