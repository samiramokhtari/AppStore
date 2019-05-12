using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.UI.Models
{
    public class ShowProductDetiels
    {
        public Product Product { get; set; }
        public CountsViewModel Counts { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}