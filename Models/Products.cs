using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Products
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter the unit price.")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a positive value.")]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the brand id.")]
        public int BrandId { get; set; }

        public Brands Brand { get; set; }
        [Required(ErrorMessage = "Please enter the id category.")]
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
        [Required(ErrorMessage = "Please enter image url.")]
        public string ImgUrl { get; set; }

        public List<Colors> Colors { get; set; }

        public List<OrderItems> OrderItems { get; set; }

        public List<Warehouses> Warehouses { get; set; }

        public List<ProductSpecifications> ProductSpecifications { get; set; }

        public Products(int productId, string productName, double unitPrice, string description, Brands brand, Categories category, string imgUrl)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Description = description;
            Brand = brand;
            Category = category;
            ImgUrl = imgUrl;
            BrandId = brand.brand_id;
            CategoryId = category.category_id;
            Colors = new List<Colors>();
            OrderItems = new List<OrderItems>();
            Warehouses = new List<Warehouses>();
            ProductSpecifications = new List<ProductSpecifications>();
        }

        public Products() { }
    }
}
