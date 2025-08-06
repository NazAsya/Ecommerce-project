using Ecommerce.API.Models;


namespace Ecommerce.API.Models
{
    public class OrderItem
    {
    public int Id { get; set; }               
     // Sipariş kalemi ID
     public int OrderId { get; set; }
     // Hangi siparişe ait
      public int Quantity { get; set; }
     // Kaç adet ürün
     public int ProductId { get; set; }        
     public Product Product { get; set; }   
        
     public Order Order { get; set; }
     
     
    }
}
