using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
