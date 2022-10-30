using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;

namespace RookiesShop.CustomerSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private IProductService _productService;

        public CartController(ILogger<CartController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            IEnumerable<ProductDto> listProducts = await _productService.GetProducts();
            return View(listProducts);
        }

    

        
    }
}