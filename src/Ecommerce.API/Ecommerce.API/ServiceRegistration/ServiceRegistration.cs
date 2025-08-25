using Ecommerce.API.Models.Data;
using Ecommerce.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.ServiceRegistration
{
    public static class ServiceRegistration
    {
      public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

         services.AddScoped<IUserReadRepository, UserReadRepository>();
         services.AddScoped<IUserWriteRepository, UserWriteRepository>();
         
         services.AddScoped<IProductReadRepository, ProductReadRepository>();
         services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
         
         services.AddScoped<IOrderReadRepository, OrderReadRepository>();
         services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
         
         services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
         services.AddScoped<IOrderItemWriteRepository, OrderItemWriteRepository>();
         
         services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
         services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

         services.AddScoped<IUnitOfWork, UnitOfWork>();

        }



    }
}
