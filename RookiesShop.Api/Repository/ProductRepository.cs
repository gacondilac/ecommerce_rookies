using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task Create(Product product);
        bool SaveChanges();
        public void UpdateProduct(Product product);
        public Task DeleteProduct(int id);

    }
    public class ProductRepository : IProductRepository
    {
        private RookieShopdbcontext _dbContext;
        private bool disposed=false;

        public ProductRepository(RookieShopdbcontext dbContext)
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
        public async Task Create(Product product)
        {
            _dbContext.Add(product);

        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
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
