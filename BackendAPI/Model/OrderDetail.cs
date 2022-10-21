using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        public int NumProduct { get; set; }
        [Required]
        [Column("TotalPrice")]
        public float Total { get; set; }
        


    }
}
