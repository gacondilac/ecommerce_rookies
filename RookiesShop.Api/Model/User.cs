using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RookiesShop.Api.Model
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    

    }
}
