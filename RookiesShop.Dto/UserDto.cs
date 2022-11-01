
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace RookiesShop.Dto
{
    public class UserDto
    {
        
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public bool RememberMe { get; set; }

    }
}
