using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string FileSize { get; set; }
        public virtual Group Group { get; set; }
        [ForeignKey("Group")]
        public int Group_Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserDownload> UserDownloads { get; set; }
        public virtual ICollection<BookMark> BookMarks { get; set; }
        public string FileUpload { get; set; }
        public double Rate { get; set; }
        public float Version { get; set; }
        public string Developer { get; set; }
        public bool License { get; set; }

        public ProductImage Logo
        {
            get
            {
                if (ProductImages == null)
                    return null;
                return ProductImages.FirstOrDefault(x => x.Type == ImageType.Logo);
            }
        }
        [NotMapped()]
        public int LogoIndex { get; set; }
    }
}
