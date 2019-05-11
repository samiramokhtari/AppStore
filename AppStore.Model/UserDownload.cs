using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
  public  class UserDownload
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual Product Product { get; set; }
        public DateTime DateTime { get; set; }
        public virtual User User { get; set; }

    }
}
