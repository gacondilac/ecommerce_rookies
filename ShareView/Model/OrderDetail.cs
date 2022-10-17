using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        public Product ProductID { get; set; }
        public Order OrderID { get; set; }
        public float Price { get; set; }
        public int NumProduct { get; set; }


    }
}
