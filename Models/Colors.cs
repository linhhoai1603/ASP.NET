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
        [Required(ErrorMessage = "Product id is required")]
        [Display(Name ="Product ID")]
        public int product_id { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
