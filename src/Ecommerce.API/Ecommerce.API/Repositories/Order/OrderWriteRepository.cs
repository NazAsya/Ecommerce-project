using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;

namespace Ecommerce.API.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
