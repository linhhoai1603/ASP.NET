using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please enter the product quantity .")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        [Display(Name = "Quantity")]
        public int ProductQuantity { get; set; }
        //Product Detail
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter the unit price.")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a positive value.")]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }
        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Please enter image url.")]
        [Display(Name = "imgUrl")]
        public string ImgUrL { get; set; }

    }
}
