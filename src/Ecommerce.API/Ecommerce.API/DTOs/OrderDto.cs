namespace Ecommerce.API.DTOs
{
    public class OrderDto
    {
     public Guid Id { get; set; }
     public Guid UserId { get; set; }
     public DateTime OrderDate{ get; set; }
     public decimal TotalPrice { get; set; }
     public List<OrderItemDto> Items { get; set; }
    }
}
