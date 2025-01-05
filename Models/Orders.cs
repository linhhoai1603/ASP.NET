namespace ProjectDotNET.Models
{
    public class Orders
    {
        public int order_id { get; set; }
        public String order_date { get; set; }
        public double total_amount { get; set; }
        public String status { get; set; }
        public List<Order_Items> Order_Items { get; set; }
        public Orders(int order_id, string order_date, double total_amount, string status)
        {
            this.order_id = order_id;
            this.order_date = order_date;
            this.total_amount = total_amount;
            this.status = status;
            Order_Items = new List<Order_Items>();
        }
        public Orders()
        {
        }
    }
}
