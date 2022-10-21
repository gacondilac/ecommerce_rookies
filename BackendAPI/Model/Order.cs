using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        
    }
}
