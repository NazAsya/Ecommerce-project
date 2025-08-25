using Ecommerce.API.Models;

namespace Ecommerce.API.Repositories
{
    public interface ICategoryWriteRepository : IWriteRepository<Category>
    {
        void Remove(Guid id);
    }
}
