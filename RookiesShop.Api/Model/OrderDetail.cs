using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesShop.Api.Model
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required]
        [Column("Number Of product")]
        public int Amount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
