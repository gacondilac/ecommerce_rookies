using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RookiesShop.Api.Repository;
using AutoMapper;
using RookiesShop.Api.Data;
using Microsoft.VisualBasic;
using RookiesShop.Dto;
using RookiesShop.Api.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace RookiesShop.Test.Controller
{
    public class CategoriesControllerTests
    {
        private RookieShopdbcontext _context;
        private ICategoryRepository _IcategoryRepository;
        private IMapper _mapper; 

        public CategoriesControllerTests()
        {
            _IcategoryRepository = A.Fake<ICategoryRepository>();
            _mapper = A.Fake<IMapper>();

        }
        [Fact]
        public void CategoryController_GetAllCategories_ReturnOK()
        {
            //arrange
            var categories = A.Fake<ICollection<CategoryDto>>();
            var categoryList=A.Fake<List<CategoryDto>>();
            A.CallTo(() => _mapper.Map<List<CategoryDto>>(categories)).Returns(categoryList);
            var controller = new CategoriesController(_context, _IcategoryRepository, _mapper);
            //act
            var result = controller.GetAllCategories();

            //assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
