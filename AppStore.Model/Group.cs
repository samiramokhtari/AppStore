using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{

    public enum TypeGroup
    {
        Application = 0,
        Game = 1
    }
    public class Group : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeGroup Type { get; set; }
        public ICollection<Product> Products { get; set; }
        // public ICollection<Group> SubGroups { get; set; }
        // public Group Parent { get; set; }
    }
}
