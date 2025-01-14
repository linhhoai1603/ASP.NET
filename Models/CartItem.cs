namespace Models
{
    public class CartItem
    {
      public int ProductId { get; set; }
      public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

    }
}
