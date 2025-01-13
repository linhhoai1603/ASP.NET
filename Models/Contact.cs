using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("contacts")]
    public class Contact
    {
        [Key]
        [Column("contactId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Contact ID")]
        public int ContactId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        [Column("fullName")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Column("email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [Column("phone")]
        [StringLength(15)]
        public string Phone { get; set; }
        [Display(Name = "Message")]
        [Column("message")]
        [Required]
        public string Message { get; set; }
    }
}