using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public double LastPrice { get; set; }
        public double TotalArea { get; set; }

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
            TotalQuantity = 0;
            TotalPrice = 0;
            LastPrice = 0.0;
        }

        // Method to add an item
        public void Add(CartItem item)
        {
            if (item.Quantity < 0) return;

            int idColor = item.Color.ColorId; // Adjusted to use ColorId
            if (!Items.ContainsKey(idColor))
            {
                Items[idColor] = item;
            }
            else
            {
                CartItem existing = Items[idColor];
                existing.SetQuantity(existing.Quantity + item.Quantity);
            }

            CalculateInfo();
        }

        // Method to calculate all costs and values (without shipping fee)
        private void CalculateInfo()
        {
            double price = 0.0;
            int quantity = 0;

            foreach (var item in Items.Values)
            {
                quantity += item.Quantity;
                price += item.TotalPrice;
            }

            TotalQuantity = quantity;
            TotalPrice = price;
            LastPrice = TotalPrice;
        }

        // Method to remove an item
        public void Remove(int idColor)
        {
            Items.Remove(idColor);
            CalculateInfo();
        }

        // Method to update the quantity of an item
        public void UpdateQuantity(int idColor, int quantity)
        {
            CartItem item = Items[idColor];
            item.SetQuantity(quantity);
            CalculateInfo();
        }

        // Method to get all items as a list
        public List<CartItem> GetValues()
        {
            return Items.Values.ToList();
        }

        public override string ToString()
        {
            return $"Cart{{Items={Items}, TotalQuantity={TotalQuantity}, TotalPrice={TotalPrice}}}";
        }
    }
}
