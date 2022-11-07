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
    public class AccountService : IAccountService
    {
        private readonly IAccountData _accountData;

        // Initialize
        public AccountService()
        {
            _accountData = RestService.For<IAccountData>("https://localhost:7264");
        }


        // Methods
        public async Task<string> Register(RegisterDto registerDto)
        {
            return await _accountData.Register(registerDto);
        }


        public async Task<string> SignIn(SignInDto signInDto)
        {
            return await _accountData.SignIn(signInDto);
        }
    }
}
