using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services
{
    public class OrderItem_Service : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItem_Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _unitOfWork.OrderItemWriteRepository.AddAsync(orderItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderItemAsync(Guid Id)
        {
            var orderItem = await _unitOfWork.OrderItemReadRepository.GetByIdAsync(Id);
            if (orderItem != null)
            {
                _unitOfWork.OrderItemWriteRepository.Remove(orderItem);
                await _unitOfWork.CompleteAsync();
            }
        }

       public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _unitOfWork.OrderItemReadRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid Id)
        {
            return await _unitOfWork.OrderItemReadRepository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderByIdAsync(Guid orderId)
        {
         return await _unitOfWork.OrderItemReadRepository.GetWhereAsync(oi => oi.OrderId == orderId);
        }

        public Task<OrderItem> GetOrderItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _unitOfWork.OrderItemWriteRepository.Update(orderItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
