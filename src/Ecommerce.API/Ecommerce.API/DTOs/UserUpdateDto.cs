namespace Ecommerce.API.DTOs
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
