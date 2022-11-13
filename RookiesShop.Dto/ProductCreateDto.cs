using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookiesShop.Dto
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
