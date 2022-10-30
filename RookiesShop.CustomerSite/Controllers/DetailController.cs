using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;

namespace RookiesShop.CustomerSite.Controllers
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;
        private IProductService _productService;

        public DetailController(ILogger<DetailController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute]int id)
        {

            ProductDto productDtos = await _productService.GetProductById(id);

            return View(productDtos);
        }


    }
}