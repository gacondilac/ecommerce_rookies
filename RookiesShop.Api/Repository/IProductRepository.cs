using Microsoft.AspNetCore.Mvc;
using RookiesShop.Api.Model;
using RookiesShop.Api.Paging;
using RookiesShop.Dto;

namespace RookiesShop.Api.Repository
{
    public interface IProductRepository
    {
        PagedList<Product> GetProducts(PageParameters pageParameters);
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task Create(Product product);
        bool SaveChanges();
        Task UpdateProduct( ProductDto productDto);

    }
  
}
