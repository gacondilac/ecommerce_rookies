using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Repository
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategory();
        public Task Create(Category category);
        bool SaveChanges();
        public void UpdateCategory(Category category);
        public Task DeleteCategory(int id);

    }
    public class CategoryRepository : ICategoryRepository
    {
        private RookieShopdbcontext _dbContext;
        private bool disposed=false;

        public CategoryRepository(RookieShopdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        //method
        public async Task<List<Category>> GetCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }
      
       
        public async Task Create(Category category)
        {
            _dbContext.Add(category);

        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
        }
        public async Task DeleteCategory(int id)
        {
            Category category = await _dbContext.Categories.FindAsync(id);
            _dbContext.Categories.Remove(category);
        }
    }
}
