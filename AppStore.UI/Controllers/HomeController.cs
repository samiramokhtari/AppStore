using AppStore.Models;
using AppStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> Products = new Biz.ProductBiz().GetAll();



            var GameApps = new Biz.GroupBiz().GetAll().Where(x => x.Type == AppStore.Models.TypeGroup.Game).SelectMany(p => p.Products).ToList();



            var NewApps = Products.OrderByDescending(x => x.DateTime).Take(20).ToList();


            HomeProducts result = new HomeProducts()
            {
                Games = GameApps,
                NewApps = NewApps,

            };

            var Downloads = new Biz.DownloadBiz().GetAll();
            var mostDownload = (from t in Downloads
                                group t by t.Product.Id
                                into g
                                select new
                                {
                                    ProductId = g.Key,
                                    Count = g.Count()
                                }).OrderByDescending(x => x.Count)
                                .Select(x => x.ProductId)
                                .Take(20)
                                .ToList();
            result.MostDownloaded = Products.Where(x => mostDownload.Contains(x.Id)).ToList();


            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}