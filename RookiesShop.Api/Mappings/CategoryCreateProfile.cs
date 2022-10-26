using AutoMapper;
using RookiesShop.Api.Data;
using RookiesShop.Dto;
using Microsoft.AspNetCore.Identity;
using RookiesShop.Api.Model;
namespace RookiesShop.Api.Mappings
{
    public class CategoryCreateProfile :Profile
    {
        public CategoryCreateProfile ()
        {
               CreateMap<Category, CategoryDto>();
            
              

        }
    }
}
