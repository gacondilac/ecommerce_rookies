using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Dto;

namespace RookiesShop.Api.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task Create(Product product);
        bool SaveChanges();
        public Task UpdateProduct( ProductDto productDto);

    }
    public class ProductRepository : IProductRepository
    {
        private readonly RookieShopdbcontext _dbContext;
        private readonly IMapper _mapper;
        private bool disposed=false;

        public ProductRepository(RookieShopdbcontext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //method
        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products.Include(product=>product.Category).ToListAsync();
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
        public async Task UpdateProduct( ProductDto productDto)
        {
           
                var updateProduct = _mapper.Map<Product>(productDto);
                _dbContext.Products.Update(updateProduct);
                await _dbContext.SaveChangesAsync();
            
        }
       
    }
}
