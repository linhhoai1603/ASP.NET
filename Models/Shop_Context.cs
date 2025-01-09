using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql; // Chỉ cần dùng Pomelo.EntityFrameworkCore.MySql
using ProjectDotNET.Models;

namespace ProjectDotNET.Models
{
    public class Shop_Context : DbContext
    {
        public Shop_Context(DbContextOptions<Shop_Context> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } // Đổi tên bảng cho đúng convention
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
