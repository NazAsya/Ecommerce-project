using Ecommerce.API.Models;
using Ecommerce.API.Models.Common;


namespace Ecommerce.API.Models
{
    public class Order: BaseEntity
    {
        public Guid Id { get; set; }                       
        // Sipariş ID
        public Guid UserId { get; set; }                   
        // Siparişi veren kullanıcı
        public DateTime OrderDate { get; set; }          
        // Sipariş tarihi
        
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        // Siparişe ait ürünler. Çünkü bir siparişin birden fazla ürünü olabilir bu yüzden Icollection kullanırız.
        public User Users { get; set; }
    }
}
