using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppStore.Models;

namespace AppStore.UI.Models
{
    public class HomeProducts
    {
        public List<Product> NewApps{ get; set; }
        public List<Product> MostDownloaded { get; set; }
        public List<Product> Games { get; set; }
        public List<Product> RecentlyUpdated { get; set; }

    }
}