using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string Note  { get; set; }
        public User UserID { get; set; }
    }
}
