using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareView.Model
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public Category CategoryID { get; set; }
        [Column("Description")]
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

    }
}
