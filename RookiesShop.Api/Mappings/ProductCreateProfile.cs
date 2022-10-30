using AutoMapper;
using RookiesShop.Dto;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Mappings
{
    public class ProductCreateProfile : Profile
    {
        public ProductCreateProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
