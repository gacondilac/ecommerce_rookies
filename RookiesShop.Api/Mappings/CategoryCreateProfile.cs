using AutoMapper;
using RookiesShop.Dto;
using RookiesShop.Api.Model;
namespace RookiesShop.Api.Mappings
{
    public class CategoryCreateProfile :Profile
    {
        public CategoryCreateProfile ()
        {
               CreateMap<CategoryCreateDto, Category>();
               CreateMap<Category, CategoryDto>();
        }
    }
}
