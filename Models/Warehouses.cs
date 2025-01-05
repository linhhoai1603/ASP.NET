namespace ProjectDotNET.Models
{
    public class Warehouses
    {
        public int warehouse_id { get; set; }
        public String warehouse_name { get; set; }
        public String address { get; set; }
        public int quantity { get; set; }
        public int product_id { get; set; }
        public Products Products { get; set; }
        public Warehouses(int warehouse_id, String warehouse_name, String address, int quantity, Products Products)
        {
            this.warehouse_id = warehouse_id;
            this.warehouse_name = warehouse_name;
            this.address = address;
            this.quantity = quantity;
            this.product_id = Products.product_id;
            this.Products = Products;
        }
        public Warehouses()
        {
        }
    }
}
