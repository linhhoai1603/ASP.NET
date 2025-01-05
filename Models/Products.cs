using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ProjectDotNET.Models
{
    public class Products
    {
        public int product_id { get; set; }
        public String product_name { get; set; }
        public double unitPrice { get; set; }
        public String description { get; set; }
        public int brand_id { get; set; }
        public Brands Brands { get; set; }
        public int category_id { get; set; }
        public Categories Categories { get; set; }
        public String img_url { get; set; }
        public List<Colors> Colors { get; set; }
        public List<Order_Items> Order_Items { get; set; }
        public List<Warehouses> Warehouses { get; set; }
        public List<ProductSpecifications> ProductSpecifications { get; set; }

        public Products(int product_id, string product_name, double unitPrice, string description, Brands brands, Categories categories, string img_url)
        {
            this.product_id = product_id;
            this.product_name = product_name;
            this.unitPrice = unitPrice;
            this.description = description;
            Brands = brands;
            Categories = categories;
            this.img_url = img_url;
            this.brand_id = brands.brand_id;
            this.category_id = categories.category_id;
            Colors = new List<Colors>();
            Order_Items = new List<Order_Items>();
            Warehouses = new List<Warehouses>();
            ProductSpecifications = new List<ProductSpecifications>();
        }

        public Products()
        {
        }
    }
}
