using Ecommerce.API.Models;


namespace Ecommerce.API.Models
{
    public class Order
    {
        public int Id { get; set; }                       
        // Sipariş ID
        public int UserId { get; set; }                   
        // Siparişi veren kullanıcı
        public DateTime OrderDate { get; set; }          
        // Sipariş tarihi
        
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        // Siparişe ait ürünler. Çünkü bir siparişin birden fazla ürünü olabilir bu yüzden Icollection kullanırız.
        public User User { get; set; }
    }
}
