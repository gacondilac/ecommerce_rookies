using AutoMapper;
using RookiesShop.Dto;
using RookiesShop.Api.Model;
using Microsoft.AspNetCore.Identity;

namespace RookiesShop.Api.Mappings
{
    public class Automaper :Profile
    {
        public Automaper ()
        {
               CreateMap<CategoryCreateDto, Category>();

               CreateMap<Category, CategoryDto>();

               CreateMap<CategoryDto, Category>();

               CreateMap<ProductCreateDto, Product>();

               CreateMap<Product, ProductDto>()
                .ForMember(dest=>dest.CategoryName,otp=> otp.MapFrom(src=> src.Category.Name));

               CreateMap<ProductDto, Product>();

            CreateMap<User, UserDto>()
            
             .ForMember(des => des.Email, act => act.MapFrom(src => src.Email))
             .ForMember(des=>des.PhoneNumber,act=> act.MapFrom(src=>src.PhoneNumber));
        }
    }
}
