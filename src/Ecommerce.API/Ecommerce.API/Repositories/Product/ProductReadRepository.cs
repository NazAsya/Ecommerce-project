using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
         return await base.GetByIdAsync(id);
        }
    }
}
