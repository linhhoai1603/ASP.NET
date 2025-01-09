using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class OrderItemsVM
    {
        [Required(ErrorMessage = "Please enter the price")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter the quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
            set
            { }
        }
        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Please enter the product description.")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please enter product image url.")]
        [Display(Name = "PrductImgUrl")]
        public string ProductImgUrl { get; set; }
        [Required(ErrorMessage = "Color name is required")]
        [Display(Name = "Color Name")]
        public string ColorName { get; set; }
        [Required(ErrorMessage = "Color image is required")]
        [StringLength(200)]
        public string ColorImg { get; set; }
    }
}
