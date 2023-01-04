using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using RookiesShop.Api.Data;
using RookiesShop.Api.Model;
using RookiesShop.Api.Repository;
using RookiesShop.Dto;
namespace RookiesShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase

    {
        private RookieShopdbcontext _context;
        private ICategoryRepository _IcategoryRepository;
        private IMapper _mapper;
        public CategoriesController(RookieShopdbcontext context, ICategoryRepository icategoryRepository, IMapper mapper)
        {
            _context = context;
            _IcategoryRepository = icategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            List<Category> Categories = await _IcategoryRepository.GetCategory();
            List<CategoryDto> CategoryDtos = _mapper.Map<List<CategoryDto>>(Categories);
            return Ok(CategoryDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByIds([FromRoute] int id)
        {
            Category Categories = await _IcategoryRepository.GetCategoryById(id);
            if (Categories == null)
            {
                return NotFound("No product with Given Id");
            }
            CategoryDto CategoryDtos = _mapper.Map<CategoryDto>(Categories);

            return Ok(CategoryDtos);
        }

        // GET: api/Product/5

        //done

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryCreateDto>> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            //mapping to data
            var categoryModel = _mapper.Map<Category>(categoryCreateDto);
            _IcategoryRepository.Create(categoryModel);
            _IcategoryRepository.SaveChanges();
            //mapp from product to dto
            var categoryDto = _mapper.Map<CategoryDto>(categoryModel);

            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory( CategoryDto categoryDto)
        {
            
            await _IcategoryRepository.UpdateCategory( categoryDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

       
    }
   
    //PUT

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


