using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;

namespace Ecommerce.API.Repositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
