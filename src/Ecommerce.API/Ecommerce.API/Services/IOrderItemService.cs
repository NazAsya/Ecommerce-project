using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface IOrderItemService
    {
     Task<IEnumerable<OrderItem>> GetAllAsync();
     Task<OrderItem> GetOrderItemByIdAsync(Guid id);
     Task AddOrderItemAsync(OrderItem orderItem);
     Task UpdateOrderItemAsync(OrderItem orderItem);
     Task DeleteOrderItemAsync(Guid Id);

    Task<IEnumerable<OrderItem>> GetOrderByIdAsync(Guid orderId);
    }
}
