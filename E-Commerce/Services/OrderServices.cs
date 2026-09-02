using E_Commerce.DTO;
using E_Commerce.Models;
using E_Commerce.Repositories;
using Hangfire;

namespace E_Commerce.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public OrderServices(
            IOrderRepository orderRepository,
            IBackgroundJobClient backgroundJobClient)
        {
            _orderRepository = orderRepository;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task<OrderResponseDto> CreateOrder(OrdersDto dto)
        {
            var order = new Order
            {
                CustomerEmail = dto.CustomerEmail,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                OrderItems = dto.OrderItems.Select(item => new OrderItem
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            order.TotalAmount = order.OrderItems.Sum(item => item.Price * item.Quantity);

            await _orderRepository.AddAsync(order);

            _backgroundJobClient.Enqueue<OrderProcessingServices>(
                job => job.ProcessOrder(order.Id));

            return OrderResponseDto.FromEntity(order);
        }

        public async Task<OrderResponseDto?> GetById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order is null ? null : OrderResponseDto.FromEntity(order);
        }
    }
}
