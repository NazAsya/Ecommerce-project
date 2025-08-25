using Microsoft.AspNetCore.Identity;

namespace Ecommerce.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
