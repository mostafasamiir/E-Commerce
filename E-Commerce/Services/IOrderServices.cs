using E_Commerce.DTO;

namespace E_Commerce.Services
{
    public interface IOrderServices
    {
        Task<OrderResponseDto?> GetById(int id);
        Task<OrderResponseDto> CreateOrder(OrdersDto dto);
    }
}
