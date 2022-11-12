using RookiesShop.Api.Model;
using RookiesShop.Dto;

namespace RookiesShop.Api.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategory();
        Task<Category> GetCategoryById(int id);
        Task Create(Category category);
        bool SaveChanges();
        Task UpdateCategory(CategoryDto categoryDto);

    }
  
     
    
}
