using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectDotNET.Models
{
    [Table("productSpecifications")]
    public class ProductSpecification
    {
        [Key]
        [Column("productSpeId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductSpeId { get; set; }

        [Column("ram")]
        [Required(ErrorMessage = "RAM is required")]
        [Display(Name = "RAM")]
        public string Ram { get; set; }

        [Column("resolution")]
        [Required(ErrorMessage = "Resolution is required")]
        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        [Column("storageCapacity")]
        [Required(ErrorMessage = "Storage capacity is required")]
        [Display(Name = "Storage Capacity")]
        public string StorageCapacity { get; set; }
    }
}
