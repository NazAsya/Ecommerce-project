using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface IProductService
    {
     Task<IEnumerable<Product>> GetAllProductsAsync();
     Task<Product> GetProductByIdAsync(Guid id);
     Task AddProductAsync(Product product);
     Task UpdateProductAsync(Product product);
     Task DeleteProductAsync(Guid Id);
        
        
       
    }
}
