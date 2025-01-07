using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("categories")]
    public class Categories
    {
        [Key]
        [Column("productSpeId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "category_id")]
        public int category_id { get; set; }

        [Column("categoryName")]
        [Required (ErrorMessage = "Category name is required)]")]
        [Display(Name ="Name Category")]
        [StringLength(100)]
        public String category_name { get; set; }

        public List<Products> Products { get; set; }
    }
}
