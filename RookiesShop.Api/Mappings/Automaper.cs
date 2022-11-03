using AutoMapper;
using RookiesShop.Dto;
using RookiesShop.Api.Model;
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

               CreateMap<Product, ProductDto>();

               CreateMap<ProductDto, Product>();
               
        }
    }
}
