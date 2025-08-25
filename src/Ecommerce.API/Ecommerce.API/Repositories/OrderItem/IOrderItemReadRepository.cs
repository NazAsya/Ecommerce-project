using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq.Expressions;

namespace Ecommerce.API.Repositories
{
    public interface IOrderItemReadRepository : IReadRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(Guid id);
        Task<IEnumerable<OrderItem>> GetWhereAsync(Expression<Func<OrderItem, bool>> predicate);
    }
}
