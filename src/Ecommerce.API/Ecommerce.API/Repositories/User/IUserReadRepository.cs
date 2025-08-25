using Ecommerce.API.Models;

namespace Ecommerce.API.Repositories
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid ıd);
    }


}
