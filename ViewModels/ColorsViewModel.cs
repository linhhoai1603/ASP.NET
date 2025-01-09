using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class ColorsViewModel
    {
        [Required(ErrorMessage = "Color name is required")]
        [Display(Name = "Color Name")]
        [StringLength(50)]
        public string ColorName { get; set; }
        [Required(ErrorMessage = "Color image is required")]
        [StringLength(200)]
        public string ColorImg { get; set; }
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }



    }
}
