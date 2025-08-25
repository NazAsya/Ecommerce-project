namespace Ecommerce.API.DTOs
{
    public class OrderUpdateDto
    {
     public Guid Id { get; set; }
     public DateTime OrderDate { get; set; }
     public decimal TotalPrice { get; set; }
     public List<OrderItemUpdateDto> Items { get; set; }
    }
}
