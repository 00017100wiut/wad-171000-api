using System.ComponentModel.DataAnnotations;

namespace _17100.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? Details { get; set; }

        [Required(ErrorMessage = "SKU is required")]
        public int SKU { get; set; }
    }
}
