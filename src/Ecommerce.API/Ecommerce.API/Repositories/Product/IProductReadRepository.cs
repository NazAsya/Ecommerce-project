using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Repositories
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
    }
}
