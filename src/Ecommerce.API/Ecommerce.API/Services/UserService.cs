using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services
{
    public class UserService : IUserService
    {
        
     private readonly IUnitOfWork _unitOfWork;

     public UserService(IUnitOfWork unitOfWork)
     {
      _unitOfWork = unitOfWork;
     }

      public async Task AddUserAsync(User user)
       {
       await _unitOfWork.UserWriteRepository.AddAsync(user);
       await _unitOfWork.CompleteAsync();
       }

      public async Task DeleteUserAsync(Guid Id)
        {
        var user = await _unitOfWork.UserReadRepository.GetByIdAsync(Id);
        if(user!= null)
         {
           _unitOfWork.UserWriteRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
         }

        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await _unitOfWork.UserReadRepository.GetAllAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
         return await _unitOfWork.UserReadRepository.GetSingleAsync(x => x.Email == email);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
         return await _unitOfWork.UserReadRepository.GetByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
          _unitOfWork.UserWriteRepository.Update(user);
          await _unitOfWork.CompleteAsync();
        }

        

        
    }
}
