using System.ComponentModel.DataAnnotations;

namespace ProjectDotNET.Models
{
    public class Brands
    {
        public int brand_id { get; set; }

        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public String brand_name { get; set; }
        public Brands(int brand_id, String brand_name)
        {
            this.brand_id = brand_id;
            this.brand_name = brand_name;
        }
        public Brands()
        {
        }
    }
}
