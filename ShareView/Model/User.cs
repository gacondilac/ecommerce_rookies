using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }   
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Role RoleID { get; set; }

    }
}
