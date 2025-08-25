namespace Ecommerce.API.DTOs
{
    public class OrderItemDto
    {
     public Guid Id { get; set; }
     public Guid OrderId { get; set; }
     public string ProductName { get; set; }
     public int Quantity { get; set; }
     public decimal Price { get; set; }
    }
}
