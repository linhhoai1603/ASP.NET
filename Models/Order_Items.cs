using Mysqlx.Crud;

namespace ProjectDotNET.Models
{
    public class Order_Items
    {
        public int order_item_id { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
        public int product_id { get; set; }
        public Products Products { get; set; }
        public int order_id { get; set; }
        public Orders Orders { get; set; }

        public Order_Items(int order_item_id, double price, int quantity, double totalPrice, Products products, Orders orders)
        {
            this.order_item_id = order_item_id;
            this.price = price;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
            this.product_id = products.product_id;
            this.order_id = orders.order_id;
            Products = products;
            Orders = orders;
        }
        public Order_Items()
        {
        }
    }
}
