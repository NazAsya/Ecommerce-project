using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.API.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(AppDbContext context) : base(context)
        {
        
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
          return await base.GetByIdAsync(id);
        }
    }
}
