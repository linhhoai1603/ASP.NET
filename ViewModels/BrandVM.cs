using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class BrandVM
    {
        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public string BrandName { get; set; }
    }
}
