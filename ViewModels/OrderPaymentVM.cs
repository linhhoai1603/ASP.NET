using Models;

namespace ProjectDotNET.ViewModels
{
    public class OrderPaymentVM
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
