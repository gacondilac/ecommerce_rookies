using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using RookiesShop.Api.Model;
using RookiesShop.Api.Repository;
using RookiesShop.Dto;

namespace RookiesShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
         

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(List<User>))]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {

            List<User> users = await _userRepository.GetUsers();
            List<UserDto> userDtos = _mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }
       

    }
}
