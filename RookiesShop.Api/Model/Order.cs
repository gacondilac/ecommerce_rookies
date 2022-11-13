using System.ComponentModel.DataAnnotations;

namespace RookiesShop.Api.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string ShipName { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipPhoneNumber { get; set; }
        [Required]  
        public List<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
    }
}
