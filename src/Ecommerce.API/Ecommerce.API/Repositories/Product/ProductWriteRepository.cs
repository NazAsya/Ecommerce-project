using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
       

        public ProductWriteRepository(AppDbContext context) : base(context)
        {
        }

        public async void Remove(Guid id)
        {
         var product = await Table.FirstOrDefaultAsync(c => c.Id == id);
         if (product != null)
          {
           Table.Remove(product);
          }
        }
    }
}
