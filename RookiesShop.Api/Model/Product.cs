using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesShop.Api.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column("NameProduct")]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public float Price { get; set; }
        [Required]
        [Column("ImageURL")]
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

    }
}
