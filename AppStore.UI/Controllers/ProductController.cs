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

            return View("SmallProduct", sampleProduct);
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

        [HttpPost]
        public ActionResult Create(Product p)
        {
            new Biz.ProductBiz().Create(p);
            return View(Get(p.Id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Edit(Product p, User u)
        {
            new Biz.ProductBiz().Edit(p, u);
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Product p, User u)
        {
            new Biz.ProductBiz().Delete(p, u);
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        { 
            return View();
        }
    }
}