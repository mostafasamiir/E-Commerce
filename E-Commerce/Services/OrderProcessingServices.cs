using E_Commerce.Models;

namespace E_Commerce.Services
{
    public class OrderProcessingServices
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public OrderProcessingServices(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessOrder(int orderId)
        {
            using var scope = _scopeFactory.CreateScope(); // each job run gets its own box, uses it, then throws it away.
            // scope(box) is a disposable object that creates a new scope for the services. This is important because it ensures that the services are disposed of properly after the job is done.
            var dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();// made an appdbcontext instance
            var order = await dbcontext.Orders.FindAsync(orderId);
            if (order != null)
            {
                Console.WriteLine($"Simulated Email Receipt Sent to {order.CustomerEmail}");
                await Task.Delay(5000); 
                order.Status = "Completed";
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}
