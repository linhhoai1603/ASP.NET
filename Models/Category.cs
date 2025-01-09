using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("productSpeId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Column("categoryName")]
        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
