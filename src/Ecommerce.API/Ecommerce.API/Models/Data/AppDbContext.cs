using Microsoft.EntityFrameworkCore;
using Ecommerce.API.Models;    // Entity modelleri (User, Product vs.)
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Ecommerce.API.Models.Data
{
    
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        //Veritabanı tablolarını temsil eden DbSet'ler
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
       }
}
