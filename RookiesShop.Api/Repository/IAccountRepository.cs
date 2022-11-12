using Microsoft.AspNetCore.Identity;
using RookiesShop.Dto;


namespace RookiesShop.Api.Repository
{
    public interface IAccountRepository
    {

        Task<IdentityResult> SignUpAsync(RegisterDto model);
        Task<string> SignInAsync(SignInDto model);
    }
   
}

