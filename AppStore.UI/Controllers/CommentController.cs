using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string description, int productId, int Rate)
        {
            var OperationResult = new Biz.CommentBiz().Create(new Comment() { Description = description, Product_Id = productId, UserRate = Rate });
            if (!OperationResult.Succeed)
            {
                //  Send "false"
                return Json(new { success = false, responseText = OperationResult.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                double rate = new Biz.CommentBiz().GetRate(productId);

                Product product = new Biz.ProductBiz().Get(productId);

                product.Rate = rate;
                new Biz.ProductBiz().Edit(product);
                //  Send "Success"
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
        }


        public int CommentsCount(int productId)
        {
            return new Biz.CommentBiz().CommnetsCount(productId);
        }
    }
}