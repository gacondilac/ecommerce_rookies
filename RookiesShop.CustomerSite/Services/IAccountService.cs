using Refit;
using RookiesShop.Dto;
using RookiesShop.CustomerSite.DataAccess;

namespace RookiesShop.CustomerSite.Services
{
    public interface IAccountService
    {
        Task<string> Register(RegisterDto registerDto);
        Task<string> SignIn(SignInDto signInDto);

    }
    
}
