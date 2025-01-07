using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("users")]
    public class Users
    {
        [Key]
        [Column("userId")]
        [Display(Name = "User Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // thiet lap auto increment
        public int UserId { get; set; }

        [Column("userName")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Column("password")]
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Column("role")]
        [Required(ErrorMessage = "Role is required.")]
        [Display(Name = "Role")]
        public int Role { get; set; }

        [Column("address")]
        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address")]
        [StringLength(255)]
        public string Address { get; set; }

        [Column("phone")]
        [Required(ErrorMessage = "phone contact is 10 number.")]
        [Display(Name = "Phone")]
        [StringLength(10)]
        public string Phone { get; set; }

        [Column("email")]
        [Required(ErrorMessage = "Email cannot be null or empty.")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column("fullname")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        public List<Orders> Orders { get; set; }
    }
}
