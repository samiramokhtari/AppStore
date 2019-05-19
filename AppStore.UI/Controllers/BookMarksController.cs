using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class BookMarksController : Controller
    {
        // GET: BookMarks
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Create(int productId)
        {
            new Biz.BookMarkBiz().Create(new BookMark() { Product_Id = productId});
            return View();
        }
    }
}