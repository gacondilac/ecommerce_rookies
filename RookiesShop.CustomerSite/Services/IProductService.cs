using Refit;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.DataAccess;
namespace RookiesShop.CustomerSite.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int id);

    }
  
}
