using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Service
{
    public interface IUserService
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public Task DeleteProduct(int id);

    }
    public class UserService : IUserService
    {
        private RookieShopdbcontext _dbContext;
        private bool disposed=false;

        public UserService(RookieShopdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        //method
        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int Id)
        {
            return await _dbContext.Products.FindAsync(Id);
        }
        public async Task<Product> GetProductByName(string name)
        {
            return await _dbContext.Products.FindAsync(name);
        }
        public async Task CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
        }
        public async Task DeleteProduct(int id)
        {
            Product product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
        }
    }
}
