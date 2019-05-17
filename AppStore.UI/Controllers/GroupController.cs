using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStore.UI.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        {

            var sampleGroup = new Biz.GroupBiz().Get(id);

            return View("Details", sampleGroup);
        }

        public ActionResult Manage()
        {
            return View(GetList());
        }

        public ActionResult List()
        {
            return View(GetList());
        }
        private List<Group> GetList()
        {
            return new Biz.GroupBiz().GetAll();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(Group g)
        {
            var result = new Biz.GroupBiz().Create(g);
            if (result.Succeed)
                return RedirectToAction("Manage");
            return View(g);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Group());
        }

        [HttpPost]
        public ActionResult Edit(Group g, User u)
        {
            new Biz.GroupBiz().Edit(g, u);
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Group g, User u)
        {
            new Biz.GroupBiz().Delete(g, u);
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
    }
}