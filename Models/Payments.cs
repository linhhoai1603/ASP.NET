namespace ProjectDotNET.Models
{
    public class Payments
    {
        public int payment_id { get; set; }
        public double amount { get; set; }
        public String status { get; set; }
        public DateTime payment_date { get; set; }
        public String payment_method { get; set; }
        public int order_id { get; set; }
        public Orders Orders { get; set; }
        public Payments(int payment_id, double amount, string status, DateTime payment_date, string payment_method, Orders orders)
        {
            this.payment_id = payment_id;
            this.amount = amount;
            this.status = status;
            this.payment_date = payment_date;
            this.payment_method = payment_method;
            this.order_id = orders.order_id;
            Orders = orders;
        }
        public Payments()
        {
        }
    }
}
