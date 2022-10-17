using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public int Rate { get; set; } = 5;
        public Product ProductID { get; set; }
        public User UserID { get; set; }
    }
}
