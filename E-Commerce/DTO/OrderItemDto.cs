using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class OrderItemDto
    {
        [Required]
        [MaxLength(256)]
        public required string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}
