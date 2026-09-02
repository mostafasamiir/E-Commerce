using E_Commerce.Models;

namespace E_Commerce.Services
{
    public interface IOrderServices
    {
        Task <Order> GetById(int id);
        Task<Order> CreateOrder(Order order);
    }
}
