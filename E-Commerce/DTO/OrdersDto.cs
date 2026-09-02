using E_Commerce.Models;

namespace E_Commerce.DTO
{
    public class OrdersDto
    {
        public required string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
