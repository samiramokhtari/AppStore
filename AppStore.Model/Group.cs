using System;
using System.Collections.Generic;
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
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeGroup Type { get; set; }
    }
}
