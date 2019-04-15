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
            return View("Index");
        }


        public ActionResult Manage()
        {
            return View();
        }
    }
}