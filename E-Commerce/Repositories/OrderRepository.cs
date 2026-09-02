using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order order)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalSalesForDateAsync(DateTime dateUtc)
        {
            var start = dateUtc.Date;
            var end = start.AddDays(1);

            return await _context.Orders
                .Where(o => o.Status == OrderStatus.Completed
                             && o.CreatedAt >= start
                             && o.CreatedAt < end)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0m; //(decimal?) Returns null if the sequence is empty, otherwise returns the sum
        }
    }
}
