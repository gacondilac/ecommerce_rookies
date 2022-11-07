using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using RookiesShop.Api.Data;
using RookiesShop.Api.Model;

namespace RookiesShop.Api.Repository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();


    }
    public class UserRepository : IUserRepository
    {
        private RookieShopdbcontext _dbContext;
      private UserManager<User> _userManager;

        public UserRepository(RookieShopdbcontext dbContext,  UserManager<User> userManager )
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        //method
        public async Task<List<User>> GetUsers()
        {
           
              return _userManager.Users.ToList();
           
        }
        
       
    }
}
