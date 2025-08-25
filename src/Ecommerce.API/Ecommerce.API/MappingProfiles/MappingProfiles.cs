using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;

namespace Ecommerce.API.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
         
         CreateMap<User, UserDto>().ReverseMap();
         CreateMap<UserCreateDto, User>();
         CreateMap<UserUpdateDto, User>();

        
         CreateMap<Product, ProductDto>().ReverseMap();
         CreateMap<ProductCreateDto, Product>();
         CreateMap<ProductUpdateDto, Product>();

           
         CreateMap<Category, CategoryDto>().ReverseMap();
         CreateMap<CategoryCreateDto, Category>();
         CreateMap<CategoryUpdateDto, Category>();

         CreateMap<Order, OrderDto>().ReverseMap();
         CreateMap<OrderCreateDto, Order>();
         CreateMap<OrderUpdateDto, Order>();

         CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Products.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Products.Price))
                .ReverseMap();
         CreateMap<OrderItemCreateDto, OrderItem>();
         CreateMap<OrderItemUpdateDto, OrderItem>();
        }
    }
}
