using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services
{
    public class OrderService : IOrderService
    {
     private readonly IUnitOfWork _unitOfWork;

     public OrderService(IUnitOfWork unitOfWork)
        {
         _unitOfWork = unitOfWork;
        }
        public async Task AddOrderAsync(Order order)
        {
         await _unitOfWork.OrderWriteRepository.AddAsync(order);
         await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderAsync(Guid Id)
        {
         var order = await _unitOfWork.OrderReadRepository.GetByIdAsync(Id);
            if (order != null)
            {
             _unitOfWork.OrderWriteRepository.Remove(order);
              await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
          return await _unitOfWork.OrderReadRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
         return await _unitOfWork.OrderReadRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderAsync(Order order)
        {
          _unitOfWork.OrderWriteRepository.Update(order);
          await _unitOfWork.CompleteAsync();
        }
    }
}
