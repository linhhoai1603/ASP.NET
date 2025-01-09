using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class CategoryVM
    {
      
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

    }
}
