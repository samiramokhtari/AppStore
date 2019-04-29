using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AppStore.Models
{
   public enum ImageType
    {
        Logo = 0,
        Details = 1,
    }
    public class ProductImage
    {
        public int Id { get; set; }
        public ImageType  Type { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }
    }
}
