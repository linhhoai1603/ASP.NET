using ProjectDotNET.Models;
using System;

namespace Models
{
    public class CartItem
    {
        public Color Color { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public CartItem(Color color, int quantity)
        {
            this.Color = color;
            this.Quantity = quantity;
            this.TotalPrice = quantity * color.Product.UnitPrice;
        }

        public void SetQuantity(int quantity)
        {
            this.Quantity = quantity;
            this.TotalPrice = quantity * Color.Product.UnitPrice;
        }

        public override string ToString()
        {
            return $"{this.Color} {this.Quantity} {this.TotalPrice}";
        }
    }
}
