using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string FileSize { get; set; }
        public Group Group { get; set; }
        public DateTime DateTime { get; set; }
        public ProductImage Logo { get; set; }
        public List<Comment> Comments { get; set; }
        public double Rate { get; set; }
    }
}
