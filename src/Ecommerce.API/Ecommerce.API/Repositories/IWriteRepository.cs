using Ecommerce.API.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T:BaseEntity
    {
        //Write işlmelerinde ekleme, çıkarma gibi işlemler olur.
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task<bool> RemoveAsync(Guid Id);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<int> SaveAsync();

    }
}
