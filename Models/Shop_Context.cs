using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using ProjectDotNET.ViewModels;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<OrderItem> Order_Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public List<User> GetAllUser()
        {
            return Users.ToList();
        }
        public UserVM GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                return new UserVM
                {
                    Id = user.UserId,
                    Username = user.Username,
                    Phone = user.Phone,
                    Email = user.Email,
                    Address = user.Address,
                    FullName = user.FullName,
                    Password = user.Password,
                    Role = user.Role
                };
            }
            return null;
        }
        public bool UpdateUser(UserVM viewModel)
        {
            var existingUser = Users.FirstOrDefault(u => u.UserId == viewModel.Id);
            if (existingUser != null)
            {
                existingUser.Username = viewModel.Username;
                existingUser.Phone = viewModel.Phone;
                existingUser.Email = viewModel.Email;
                existingUser.Address = viewModel.Address;
                existingUser.FullName = viewModel.FullName;

                // Nếu có mật khẩu mới, mã hóa và lưu lại
                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    existingUser.Password = new PasswordHasher<UserVM>().HashPassword(viewModel, viewModel.Password);
                }

                existingUser.Role = viewModel.Role;

                SaveChanges();
                return true;
            }
            return false;
        }
    }

}
