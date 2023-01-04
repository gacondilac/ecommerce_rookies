using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RookiesShop.Api.Model;
using RookiesShop.Dto;


namespace RookiesShop.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> _userManager;
        

        public UserRepository(UserManager<User> userManager)
        {
           
            _userManager = userManager;
        }

        //method
        public async Task<List<User>> GetUsers()
        {
           
            return  _userManager.Users.ToList();
           
        }
        
       
    }
}
