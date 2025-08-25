using Ecommerce.API.Models;

namespace Ecommerce.API.Repositories
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(Guid id);

    }
}
