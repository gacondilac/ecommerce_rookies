using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using RookiesShop.CustomerSite.Models;
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
            //using HttpClientFactory
            //IEnumerable<ProductDto> products = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(baseUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

            //    HttpResponseMessage getData = await client.GetAsync("Products");

            //    if (getData.IsSuccessStatusCode)
            //    {
            //        string results = getData.Content.ReadAsStringAsync().Result;
            //        products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(results);

            //    }
            //}
            //return View(products);
            IEnumerable<ProductDto> listProducts = await _productService.GetProducts();
            return View(listProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}