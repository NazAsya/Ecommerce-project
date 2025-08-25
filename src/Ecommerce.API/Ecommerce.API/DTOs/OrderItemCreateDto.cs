namespace Ecommerce.API.DTOs
{
    public class OrderItemCreateDto
    {
     public Guid OrderId { get; set; }
     public Guid ProductId { get; set; }
     public int Quantity { get; set; }
     public decimal Price { get; set; }
    }
}
