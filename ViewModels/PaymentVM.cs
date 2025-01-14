using System.ComponentModel.DataAnnotations;
using Models;

namespace ProjectDotNET.ViewModels
{
    public class PaymentVM
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
      
        public List<CartItem> cartItems { get; set; }

    }
}
