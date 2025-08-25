using Ecommerce.API.Models;
using Ecommerce.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(AppDbContext context) : base(context)
        {
        }

        public async void Remove(Guid id)
        {
         var category = await Table.FirstOrDefaultAsync(c => c.Id == id);
          if (category != null)
            {
                Table.Remove(category);
            }
        }
    }
}
