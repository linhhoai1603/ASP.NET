using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ProjectDotNET.Models
{
    class Shop_Context : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<ProductSpecifications> ProductSpecifications { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=dotnet_db;user=root;password=;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Orders>() // 1 order có nhiều order_item
                .HasMany(o => o.Order_Items)
                .WithOne(oi => oi.Orders)
                .HasForeignKey(oi => oi.order_id);

            modelBuilder.Entity<Products>() // 1 product có nhiều order_item
                .HasMany(p => p.Order_Items)
                .WithOne(oi => oi.Products)
                .HasForeignKey(oi => oi.product_id);

            modelBuilder.Entity<Products>() // 1 product có nhiều color
                .HasMany(p => p.Colors)
                .WithOne(c => c.Products)
                .HasForeignKey(c => c.product_id);

            modelBuilder.Entity<Products>() // 1 product có nhiều warehouse
                .HasMany(p => p.Warehouses)
                .WithOne(w => w.Products)
                .HasForeignKey(w => w.product_id);

            modelBuilder.Entity<Products>() // 1 product thuộc 1 brand
                .HasOne(p => p.Brands)
                .WithMany()
                .HasForeignKey(p => p.brand_id);

            modelBuilder.Entity<Products>() // 1 product thuộc 1 category
                .HasOne(p => p.Categories)
                .WithMany()
                .HasForeignKey(p => p.category_id);

            modelBuilder.Entity<Products>() // 1 product có nhiều product_specification
                .HasMany(p => p.ProductSpecifications)
                .WithOne(ps => ps.Products)
                .HasForeignKey(ps => ps.product_id);

            modelBuilder.Entity<Payments>() // 1 payment thuộc 1 order
                .HasOne(p => p.Orders)
                .WithOne()
                .HasForeignKey<Payments>(p => p.order_id);
        }
    }
}
