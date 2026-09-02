using E_Commerce.Models;

namespace E_Commerce.DTO
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public required string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();

        public static OrderResponseDto FromEntity(Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerEmail = order.CustomerEmail,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };
        }
    }
}
