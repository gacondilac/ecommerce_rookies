using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Api.Paging;
using RookiesShop.Dto;

namespace RookiesShop.Api.Repository
{
   
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
        public PagedList<Product> GetProducts(PageParameters pageParameters)
        {
            return PagedList<Product>.ToPageList(_dbContext.Products.Include(product => product.Category),
                pageParameters.PageNumber, pageParameters.PageSize);
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
