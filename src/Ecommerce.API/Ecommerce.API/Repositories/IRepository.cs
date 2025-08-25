using Ecommerce.API.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        //<T> kısmı Generic'i belirtir ve bunu yukarıda IRepositery kısmının içine yazdığımızda bu generic class dışında farklı bir şey de olabilir ancak DbSet class olarak görmek ister içindeki bu yüzden where T: classı ekleriz ki hata almayalım.
      
      DbSet<T> Table { get; }
        
    }
}
