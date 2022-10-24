using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace RookiesShop.Api.Model
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
