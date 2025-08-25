namespace Ecommerce.API.DTOs
{
    public class OrderItemUpdateDto
    {
     public Guid Id { get; set; }
     public int Quantity { get; set; }
     public decimal Price { get; set; }
    }
}
