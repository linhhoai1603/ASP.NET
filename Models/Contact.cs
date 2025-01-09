using System.ComponentModel.DataAnnotations;

public class Contact
{
    public int ContactId { get; set; }
    [Required]
    [StringLength(100)]
    public string FullName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(15)]
    public string Phone { get; set; }
    [Required]
    public string Message { get; set; }
}
