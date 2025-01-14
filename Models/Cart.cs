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

        public void Add(CartItem item)
        {
            // Kiểm tra số lượng không hợp lệ
            if (item.Quantity <= 0) return;  // Đảm bảo số lượng phải là số dương

            int idColor = item.Color.ColorId; // Sử dụng ColorId để nhận diện sản phẩm theo màu sắc

            // Kiểm tra nếu sản phẩm chưa có trong giỏ hàng
            if (!Items.ContainsKey(idColor))
            {
                // Nếu chưa có, thêm sản phẩm mới vào giỏ hàng
                Items[idColor] = item;
            }
            else
            {
                // Nếu sản phẩm đã có trong giỏ hàng, chỉ cần cập nhật số lượng
                CartItem existing = Items[idColor];
                existing.SetQuantity(existing.Quantity + item.Quantity);
            }

            // Tính lại thông tin giỏ hàng sau khi thay đổi
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
