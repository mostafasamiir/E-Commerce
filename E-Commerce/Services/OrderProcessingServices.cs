using E_Commerce.Models;
using E_Commerce.Repositories;

namespace E_Commerce.Services
{
    public class OrderProcessingServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderProcessingServices> _logger;

        public OrderProcessingServices(
            IOrderRepository orderRepository,
            ILogger<OrderProcessingServices> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task ProcessOrder(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order is null)
            {
                _logger.LogWarning("Order {OrderId} was not found for processing.", orderId);
                return;
            }

            await Task.Delay(5000);

            _logger.LogInformation(
                "Simulated email receipt sent to {CustomerEmail} for order {OrderId}.",
                order.CustomerEmail,
                order.Id);

            order.Status = OrderStatus.Completed;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
