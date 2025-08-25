using Ecommerce.API.Models;

namespace Ecommerce.API.Repositories
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
        void Remove(Guid ıd);
    }
}
