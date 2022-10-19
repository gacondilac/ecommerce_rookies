using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Category
    {
        [Key]   
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
