using RookiesShop.Api.Model;

namespace RookiesShop.Api.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();


    }
       
    
}
