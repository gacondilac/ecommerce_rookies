﻿using AutoMapper;
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
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            List<Category> Categories = await _IcategoryRepository.GetCategory();
            List<CategoryDto> CategoryDtos = _mapper.Map<List<CategoryDto>>(Categories);
            return CategoryDtos;
        }

        // GET: api/Product/5
        
        //done
        
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProductCreateDto>> CreateCategory(CategoryCreateDto categoryCreateDto)
        //{
        //    //mapping to data
        //    var categoryModel=_mapper.Map<Category>(categoryCreateDto);
        //    _IcategoryService.Create(categoryModel);
        //    _IcategoryService.SaveChanges();
        //    //mapp from product to dto
        //    var categoryDto =_mapper.Map<CategoryCreateDto>(categoryModel);
          
        //    return Ok(categoryDto);

            
        //}

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      

       
        // DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.Id == id);
        //}

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

