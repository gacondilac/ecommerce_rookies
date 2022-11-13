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
    public class ProductService : IProductService
    {
        private readonly IProductData _productInterface;
        
        public ProductService()
        {
            _productInterface=RestService.For<IProductData>("https://localhost:7264");
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return await _productInterface.GetAllProducts();
        }
        public async Task<ProductDto> GetProductById(int Id)
        {
            return await _productInterface.GetProductByid(Id);
        }
    }
}
