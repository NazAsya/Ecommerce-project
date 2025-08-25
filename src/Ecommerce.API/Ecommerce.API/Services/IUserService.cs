using Ecommerce.API.Models;

namespace Ecommerce.API.Services
{
    public interface IUserService
    {
    Task<IEnumerable<User>> GetAllAsync();
   //Sistemdeki tüm kullanıcıları listeler.Kullanıcı listesini görüntülemek veya raporlamak için gerekir.
   Task<User> GetUserByIdAsync(Guid id);
   //Verilen id değerine sahip kullanıcıyı getirir. Guid burada kullanıcıların benzersiz kimliği olarak kullanılır
    Task AddUserAsync(User user);
    //Ne yapar? Yeni kullanıcı ekler. Kayıt veya yönetim işlemlerinde kullanılır. Parametre olarak yeni kullanıcı nesnesi alır.
    Task UpdateUserAsync(User user);
    //Var olan kullanıcı bilgilerini günceller.
    Task DeleteUserAsync(Guid Id);
    //Verilen id’ye sahip kullanıcıyı siler.
    Task<User> GetUserByEmailAsync(string email);
    //Mail adresine göre kullanıcıyı getirir. 
    }
}
