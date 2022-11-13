using Refit;
using RookiesShop.Dto;

namespace RookiesShop.CustomerSite.DataAccess
{
    public interface IAccountData
    {
        [Post("/api/Account/SignUp")]
        Task<string> Register([Body] RegisterDto registerDto);

        [Post("/api/Account/SignIn")]
        Task<string> SignIn([Body] SignInDto signInDto);
    }
    
}
