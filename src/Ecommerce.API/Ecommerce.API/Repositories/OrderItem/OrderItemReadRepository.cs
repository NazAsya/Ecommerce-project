using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.API.Repositories
{
    public class OrderItemReadRepository : ReadRepository<OrderItem>, IOrderItemReadRepository
    {
        public OrderItemReadRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
         return await base.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetWhereAsync(Expression<Func<OrderItem, bool>> predicate)
        {
           return await Table.Where(predicate).ToListAsync();
        }

    }
}
