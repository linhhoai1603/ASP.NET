using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required.")]
        [Display(Name = "Role")]
        public int Role { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string Address { get; set; }
        [Required(ErrorMessage = "phone contact is 10 number.")]
        [Display(Name = "Phone")]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email cannot be null or empty.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public string FullName { get; set; }
    }
}
