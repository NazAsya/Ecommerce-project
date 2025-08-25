using Ecommerce.API.Models;
using Ecommerce.API.Models.Common;


namespace Ecommerce.API.Models
{
    public class OrderItem: BaseEntity
    {
    public Guid Id { get; set; }               
     // Sipariş kalemi ID
     public Guid OrderId { get; set; }
     // Hangi siparişe ait
      public int Quantity { get; set; }
     // Kaç adet ürün
     public Guid ProductId { get; set; }        
     public Product Products { get; set; }   
        
     public Order Orders { get; set; }
     
     
    }
}
