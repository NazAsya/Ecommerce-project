using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface ICategoryService
    {
     Task<IEnumerable<Category>> GetAllCategoriesAsync();
     Task<Category> GetCategoryByIdAsync(Guid Id);
     Task AddCategoryAsync(Category category);
     Task UpdateCategoryAsync(Category category);
     Task DeleteCategoryAsync(Guid Id);
   
    }
}
