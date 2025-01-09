using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class ProductSpecViewModel
    {
        [Required(ErrorMessage = "RAM is required")]
        [Display(Name = "RAM")]
        public string Ram { get; set; }
        [Required(ErrorMessage = "Resolution is required")]
        [Display(Name = "Resolution")]
        public string Resolution { get; set; }
        [Required(ErrorMessage = "Storage capacity is required")]
        [Display(Name = "Storage Capacity")]
        public string StorageCapacity { get; set; }
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

    }
}
