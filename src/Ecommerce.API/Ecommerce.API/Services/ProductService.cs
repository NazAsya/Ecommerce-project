using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services
{
    public class ProductService : IProductService
    {
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }

      
        public async Task AddProductAsync(Product product)
      {
       await _unitOfWork.ProductWriteRepository.AddAsync(product);
       await _unitOfWork.CompleteAsync();
      }

        public async Task DeleteProductAsync(Guid Id)
        {
         var product = await _unitOfWork.ProductReadRepository.GetByIdAsync(Id);
            if (product != null)
            {
             _unitOfWork.ProductWriteRepository.Remove(Id);
             await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
         return await  _unitOfWork.ProductReadRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
         return await _unitOfWork.ProductReadRepository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
          _unitOfWork.ProductWriteRepository.Update(product);
          await _unitOfWork.CompleteAsync();
        }
    }
}
