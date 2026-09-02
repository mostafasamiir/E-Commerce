using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class OrdersDto
    {
        [Required]
        [EmailAddress]
        public required string CustomerEmail { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "An order must contain at least one item.")]
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
