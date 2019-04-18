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
        public Comment Comments { get; set; }
        public UserDownload UserDownload { get; set; }
    }
}