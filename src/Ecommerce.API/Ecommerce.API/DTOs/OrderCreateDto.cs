namespace Ecommerce.API.DTOs
{
    public class OrderCreateDto
    {
     public Guid UserId { get; set; }
     public DateTime OrderDate { get; set; }
     public decimal TotalPrice { get; set; }

    public List<OrderItemCreateDto> Items { get; set; }
    }
}
