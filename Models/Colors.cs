namespace ProjectDotNET.Models
{
    public class Colors
    {
        public int color_id { get; set; }
        public String color_name { get; set; }
        public String color_img { get; set; }
        public int product_id { get; set; }
        public Products Products { get; set; }
        public Colors(int color_id, String color_name, String color_img, Products Products)
        {
            this.color_id = color_id;
            this.color_name = color_name;
            this.color_img = color_img;
            this.product_id = Products.product_id;
            this.Products = Products;
        }
        public Colors()
        {
        }
    }
}
