using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("brands")]
    public class Brands
    {
        [Key]
        [Column("brandId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "brandId")]
        public int brand_id { get; set; }

        [Column("brandName")]
        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public String brand_name { get; set; }

        public List<Products> Products { get; set; }
    }
}
