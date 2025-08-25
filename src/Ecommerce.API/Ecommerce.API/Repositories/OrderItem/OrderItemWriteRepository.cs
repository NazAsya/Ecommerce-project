using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;

namespace Ecommerce.API.Repositories
{
    public class OrderItemWriteRepository : WriteRepository<OrderItem>, IOrderItemWriteRepository
    {
        public OrderItemWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
