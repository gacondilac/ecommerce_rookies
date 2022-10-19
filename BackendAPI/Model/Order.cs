using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public string Note  { get; set; }
        public int ProductID { get; set; }
    }
}
