using AppStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Product p)
        {
            if (Request.Files.Count > 0)
            {
                p.ProductImages = new List<ProductImage>();
                string path = Server.MapPath("~/Content/images/iconProduct/");
                int counter = 0;
                foreach (HttpPostedFileBase file in Request.Files.GetMultiple("Logo"))
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(path + fileName);

                    p.ProductImages.Add(new ProductImage()
                    {
                        ImageName = fileName,
                        Type = counter == p.LogoIndex ? ImageType.Logo : ImageType.Details
                    });

                    counter++;
                }
            }

            var result = new Biz.ProductBiz().Create(p);

            if (result.Succeed)
                return RedirectToAction("Manage");
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {


            ViewBag.Groups = new Biz.GroupBiz().GetAll().Select(x =>
                        new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });

            //ViewBag.TypeImages = new Biz.ProductImageBiz().GetAll().Select(x =>
            //            new SelectListItem
            //            {
            //                Value = x.Id.ToString(),
            //                Text = Enum.Parse(typeof(ImageType), x.Type.ToString()).ToString()
            //            });
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