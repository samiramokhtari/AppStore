using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class UserDownloadsController : Controller
    {
        // GET: UserDownloads
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Download(int productId)
        {
            OperationResult result = new Biz.DownloadBiz().Create(new UserDownload() { Product_Id = productId });
            if (result.Succeed)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\Downloads\\";
                string fileName = new Biz.ProductBiz().GetAll().Where(x => x.Id == productId).Select(x => x.FileUpload).FirstOrDefault();
                //TODO : Name File Download
                byte[] fileBytes = System.IO.File.ReadAllBytes(path + fileName);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            }
            return File(new byte[0] { }, System.Net.Mime.MediaTypeNames.Application.Octet, "notFound.txt");

        }


        public int CountDownloads(int ProductId)
        {
            return new Biz.DownloadBiz().Get(ProductId);
        }


    }
}