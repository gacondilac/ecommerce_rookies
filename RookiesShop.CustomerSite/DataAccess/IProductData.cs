using Refit;
using RookiesShop.Dto;

namespace RookiesShop.CustomerSite.DataAccess
{
    [Headers("Content-Type: application/json")]
    public interface IProductData
    {
        [Get("/api/Products")]
        Task<List<ProductDto>> GetAllProducts();
        [Get("/api/Products/{id}")]
        Task<ProductDto> GetProductByid(int id);
    }
    
}
