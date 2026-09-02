using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task<decimal> GetTotalSalesForDateAsync(DateTime dateUtc);
    }
}
