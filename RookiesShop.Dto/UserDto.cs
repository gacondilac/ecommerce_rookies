
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace RookiesShop.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        

    }
}
