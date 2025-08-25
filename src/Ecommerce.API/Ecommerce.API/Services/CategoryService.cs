using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services
{
    public class CategoryService : ICategoryService
    {
      private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

       public async Task AddCategoryAsync(Category category)
        {
         await _unitOfWork.CategoryWriteRepository.AddAsync(category);
         await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
        var category= await _unitOfWork.CategoryReadRepository.GetByIdAsync(id);
        if(category!=null)
            {
             _unitOfWork.CategoryWriteRepository.Remove(id);
             await _unitOfWork.CompleteAsync();
            }
        }

       public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
         return await _unitOfWork.CategoryReadRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
         return await _unitOfWork.CategoryReadRepository.GetByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
          _unitOfWork.CategoryWriteRepository.Update(category);
           await _unitOfWork.CompleteAsync();
        }
    }
}
