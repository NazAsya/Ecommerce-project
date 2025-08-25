using Ecommerce.API.Models.Common;
using System.Linq.Expressions;



namespace Ecommerce.API.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Read işlemlerinde sorguyu göndererek tüm verileri elde etmeyi, şartlı veri gönderip şarta uyan verileri elde etmeyi ya da şartlı veri gönderip şarta uyan tek verinin elde edilmesini amaçlarız. 
        //Sorgu üzerinde çalışacaksak IQueryable kullanırız. Ek olarak Id ile veri elde edeceksek de bu kullanılır. 
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>>method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(Guid Id);


    }
}
