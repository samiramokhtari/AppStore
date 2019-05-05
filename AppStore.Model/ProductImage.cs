using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppStore.Models
{
   public enum ImageType
    {
        Logo = 0,
        Details = 1,
    }
    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ImageType  Type { get; set; }
        public string ImageName { get; set; }
        public Product Product { get; set; }
        
    }
}
