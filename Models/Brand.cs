using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        [Column("brandId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Brand Id")]
        public int BrandId { get; set; }

        [Column("brandName")]
        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public string BrandName { get; set; }

        public List<Product> Products { get; set; }
    }
}
