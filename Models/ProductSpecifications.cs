using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class ProductSpecifications
    {
        public ProductSpecifications() { }

        public int ProductSpeId { get; set; }

        [Required(ErrorMessage = "RAM is required")]
        [Display(Name = "RAM")]
        public string Ram { get; set; }

        [Required(ErrorMessage = "Resolution is required")]
        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        [Required(ErrorMessage = "Storage capacity is required")]
        [Display(Name = "Storage Capacity")]
        public string StorageCapacity { get; set; }

        [Required(ErrorMessage = "Product ID is required")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public Products Product { get; set; }

        public ProductSpecifications(int productSpeId, string ram, string resolution, string storageCapacity, Products product)
        {
            ProductSpeId = productSpeId;
            Ram = ram;
            Resolution = resolution;
            StorageCapacity = storageCapacity;
            ProductId = product.ProductId;
            Product = product;
        }
    }
}
