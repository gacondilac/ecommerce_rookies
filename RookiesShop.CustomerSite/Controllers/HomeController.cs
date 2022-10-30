using Microsoft.AspNetCore.Mvc;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.Services;

namespace RookiesShop.CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
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

            string qParams = Request.Query["Category"];
            if (qParams != null)
            {
                ViewBag.value = qParams;
                listProducts = listProducts.Where(p => p.CategoryId.ToString() == qParams);
            }
            return View(listProducts);
        }





    }
}