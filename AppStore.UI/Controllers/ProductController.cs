using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Get(int id)
        {

            var sampleProduct = new Biz.ProductBiz().Get(id);
            
            return View("SmallProduct",sampleProduct);
        }


        public ActionResult Manage()
        {
            return View(GetList());
        }

        public ActionResult List()
        {
            return View(GetList());
        }
        private List<Product> GetList()
        {
            return new Biz.ProductBiz().GetAll();
        }
    }
}