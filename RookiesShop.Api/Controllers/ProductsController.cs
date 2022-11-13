using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Api.Repository;
using RookiesShop.Dto;

namespace RookiesShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        private RookieShopdbcontext _context;
        private IProductRepository _IproductRepository;
        private ICategoryRepository _IcategoryRepository;
        private IMapper _mapper;
        public ProductsController(RookieShopdbcontext context, IProductRepository IproductRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _IproductRepository = IproductRepository;
            _mapper = mapper;
            _context = context;
            _IcategoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            List<Product> Products = await _IproductRepository.GetProducts();
            List<ProductDto> ProductsDtos = _mapper.Map<List<ProductDto>>(Products);
            return ProductsDtos;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductByIds([FromRoute] int id)
        {
            Product Products = await _IproductRepository.GetProductById(id);
            if(Products == null)
            {
                return NotFound("No product with Given Id");
            }
            ProductDto ProductDtos = _mapper.Map<ProductDto>(Products);

            return ProductDtos;
        }
        //done
        
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductCreateDto>> CreateProduct(ProductCreateDto productCreateDto)
        {
            //mapping to data
            var productModel=_mapper.Map<Product>(productCreateDto);
            _IproductRepository.Create(productModel);
            _IproductRepository.SaveChanges();
            //mapp from product to dto
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == productModel.CategoryId);
            var productDto =_mapper.Map<ProductDto>(productModel);
            productDto.CategoryName = category.Name;
            return Ok(productDto);

            
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdateProduct( ProductDto productDto)
        {
           
            await _IproductRepository.UpdateProduct(productDto);
            return Ok();
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

