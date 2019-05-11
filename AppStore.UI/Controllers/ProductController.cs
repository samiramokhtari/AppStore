using AppStore.Models;
using AppStore.UI.Models;
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
            ShowProductDetiels result = new ShowProductDetiels();
            result.Product = new Biz.ProductBiz().Get(id);
            int downloads = new Biz.DownloadBiz().Get(id);
            int comments = new Biz.CommentBiz().CommnetsCount(id);

            result.Counts = new CountsViewModel() { CommentsCount = comments, DownloadsCount = downloads, RateCounts = 0 };
            return View("SmallProduct", result);
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
                string pathImage = Server.MapPath("~/Content/images/iconProduct/");
                string pathFile = Server.MapPath("~/Content/Downloads/");
                int counterIamge = 0;
                int counterFile = 0;

                foreach (HttpPostedFileBase file in Request.Files.GetMultiple("FileUpload"))
                {
                    file.SaveAs(pathFile + file.FileName);
                    p.FileUpload = file.FileName;
                    p.FileSize = getFileSize(file.InputStream.Length);
                    counterFile++;
                }

                foreach (HttpPostedFileBase file in Request.Files.GetMultiple("Logo"))
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    file.SaveAs(pathImage + fileName);

                    p.ProductImages.Add(new ProductImage()
                    {
                        ImageName = fileName,
                        Type = counterIamge == p.LogoIndex ? ImageType.Logo : ImageType.Details
                    });

                    counterIamge++;
                }
            }

            var result = new Biz.ProductBiz().Create(p);

            if (result.Succeed)
                return RedirectToAction("Manage");
            return View(p);
        }

        private string getFileSize(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return String.Format("{0:0.##}{1}", len, sizes[order]);
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