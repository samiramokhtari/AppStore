using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
   public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        public int UserRate { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
    }
}
