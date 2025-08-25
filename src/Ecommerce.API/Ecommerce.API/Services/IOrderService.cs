using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface IOrderService
    {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid id);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid Id);

    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    }
}
