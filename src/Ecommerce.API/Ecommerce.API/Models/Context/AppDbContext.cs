using Microsoft.EntityFrameworkCore;
using Ecommerce.API.Models;    // Entity modelleri (User, Product vs.)
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ecommerce.API.Models.Data
{ 
public class AppDbContext : IdentityDbContext<AppUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Mevcut tablolar
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    // Eğer kendi User sınıfını kullanmak istersen IdentityUser yerine onu da kullanabilirsin
    // public class AppUser : IdentityUser { ... } 
    // ve IdentityDbContext<AppUser> yazarsın.
   }
}




