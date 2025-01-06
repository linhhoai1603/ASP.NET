using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Users
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [Display(Name = "Role")]
        public int Role { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Display(Name = "Phone")]
        [StringLength(10, ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public Users(int userId, string username, string password, int role, string address, string phone, string email, string fullName)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Role = role;
            Address = address;
            Phone = phone;
            Email = email;
            FullName = fullName;
        }

        public Users() { }
    }
}
