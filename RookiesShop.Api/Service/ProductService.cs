using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Service
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public Task DeleteProduct(int id);

    }
    public class ProductService : IProductService
    {
        private RookieShopdbcontext _dbContext;
        private bool disposed=false;

        public ProductService(RookieShopdbcontext dbContext)
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
            Product product1 = new Product();
            {
                product1.Name = product.Name;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.Image = product.Image;
                product1.CategoryId = product.CategoryId;
            }
            await _dbContext.Products.AddAsync(product1);
            await _dbContext.SaveChangesAsync();
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
