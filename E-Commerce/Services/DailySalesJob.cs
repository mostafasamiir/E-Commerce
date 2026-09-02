using E_Commerce.Repositories;

namespace E_Commerce.Services
{
    public class DailySalesJob
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<DailySalesJob> _logger;

        public DailySalesJob(
            IOrderRepository orderRepository,
            ILogger<DailySalesJob> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task CalculateDailySales()
        {
            var todayUtc = DateTime.UtcNow.Date;
            var totalSales = await _orderRepository.GetTotalSalesForDateAsync(todayUtc);

            _logger.LogInformation(
                "Daily sales for {Date}: {TotalSales}",
                todayUtc.ToString("yyyy-MM-dd"),
                totalSales);
        }
    }
}
