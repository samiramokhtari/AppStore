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

        public ActionResult Create(string description, int productId)
        {
            new Biz.CommentBiz().Create(new Comment() { Description = description, Product_Id= productId });
            return View();
        }


        public int CommentsCount(int productId)
        {
           return new Biz.CommentBiz().CommnetsCount(productId);
        }
    }
}