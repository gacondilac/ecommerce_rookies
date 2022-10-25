using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Api.Service;
using RookiesShop.Dto;

namespace RookiesShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        private RookieShopdbcontext _context;
        private IProductService _IproductService;
        private IMapper _mapper;
        public ProductsController(RookieShopdbcontext context, IProductService IproductService, IMapper mapper)
        {
            _IproductService = IproductService;
            _mapper = mapper;
            _context = context;
        }

        //
        //private readonly RookieShopdbcontext _context;

        //public ProductsController(RookieShopdbcontext context)
        //{
        //    _context = context;
        //}

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            List<Product> Products = await _IproductService.GetProducts();
            List<ProductDto> ProductsDtos = _mapper.Map<List<ProductDto>>(Products);
            return ProductsDtos;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIds([FromRoute] int id)
        {
            Product Products = await _IproductService.GetProductById(id);
            if(Products == null)
            {
                return NotFound("No product with Given Id");
            }
            ProductDto ProductDtos = _mapper.Map<ProductDto>(Products);

            return ProductDtos;
        }
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductByIds", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        //private readonly IMapper _mapper;
        //public ProductsController(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}
        //[HttpGet]
        //public ActionResult<List<Product>> GetProduct()
        //{
        //    return Ok(_context.Products.Select(Product=> _mapper.Map<ProductDto>(Product)));
        //}
    }
}

