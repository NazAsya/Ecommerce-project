using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
         return await Table.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
          return await base.GetByIdAsync(id);
        }
    }
}
