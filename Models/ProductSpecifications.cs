namespace ProjectDotNET.Models
{
    public class ProductSpecifications
    {
        public ProductSpecifications()
        {
        }

        public int product_spe_id { get; set; }
        public String ram { get; set; }
        public String resolution { get; set; }
        public String storage_capacity { get; set; }
        public int product_id { get; set; }
        public Products Products { get; set; }
        public ProductSpecifications(int product_spe_id, String ram, String resolution, String store_capacity, Products Products)
        {
            this.product_spe_id = product_spe_id;
            this.ram = ram;
            this.resolution = resolution;
            this.storage_capacity = store_capacity;
            this.product_id = Products.product_id;
            this.Products = Products;
        }
    }
}
