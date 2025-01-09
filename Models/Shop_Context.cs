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
        public Shop_Context(DbContextOptions options) : base(options)
        {
        }

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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=dotnet_db;user=root;password=;");
        //}
    }
    
}
