using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Dto;

namespace RookiesShop.Api.Repository
{
  
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RookieShopdbcontext _dbContext;
        private readonly IMapper _mapper;
        private bool disposed=false;

        public CategoryRepository(RookieShopdbcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //method
        public async Task<List<Category>> GetCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }
         public async Task<Category> GetCategoryById( int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }
       
        public async Task Create(Category category)
        {
            _dbContext.Add(category);

        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
        public async Task UpdateCategory( CategoryDto categoryDto)
        {   
           
                var  updateCategory =_mapper.Map<Category>(categoryDto);
                _dbContext.Categories.Update(updateCategory);
                await _dbContext.SaveChangesAsync();
            
        }
     
    }
}
