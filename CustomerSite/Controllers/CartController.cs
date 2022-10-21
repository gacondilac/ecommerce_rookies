using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace CustomerSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        string baseUrl = "https://localhost:7264/api/";

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                HttpResponseMessage getData = await client.GetAsync("Products");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<IEnumerable<Product>>(results);

                }
            }
            return View(products);
        }
    }
}
