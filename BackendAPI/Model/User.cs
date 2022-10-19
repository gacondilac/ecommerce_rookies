using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please fill in the required information")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill in the required information")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please fill in the required information")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please fill in the required information")]
        public string Password { get; set; }

    }
}
