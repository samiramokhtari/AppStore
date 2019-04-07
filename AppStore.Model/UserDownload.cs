using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
  public  class UserDownload
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime DateTime { get; set; }
        public User UserId { get; set; }

    }
}
