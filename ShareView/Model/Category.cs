using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class Category
    {
        [Key]   
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
