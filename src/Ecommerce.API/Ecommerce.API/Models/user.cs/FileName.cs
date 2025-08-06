using Ecommerce.API.Models;

namespace Ecommerce.API.Models
{
    public class User
    //Class, nesne yönelimli programlamada bir varlık için şablondur. User sınıfı da kullanıcı bilgisini tutacak özelliklere sahiptir.
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        //Kullanıcının sistem içindeki rolü, örneğin admin veya müşteri. Bu enum tipinde.

       public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public enum UserRole
    {
        Admin,
        Customer,
        Seller
    }
    //Enum (enumeration), sabit değerler kümesini temsil eder.
    //UserRole, kullanıcıların alabileceği rolleri tanımlar.
    //Böylece rol değerleri string veya int gibi dağınık değil, belirlenmiş set olarak tutulur.
    //Burada da belirtildiği gibi 3 değeri vaardır. Admin, müşteri ve satıcı.
    //public enum Role { Admin, Customer, Seller } şeklinde de yazabilirdik başta. Bu şekilde Role'ü başta enum için tanımlardık ve Role sadece 3 sabit değişkenden oluşan bir veri tipi şeklinde oluşur sonra user sınıfı içerisine UserRole yazmak yerine public Role Role { get; set; } şeklinde bir kod yazabilirdik. Ama yukarıdaki kod daha güvenlidir çünkü bu şekilde ileride başka bir enum eklediğinde karışıklık olmayacak.
  
}
