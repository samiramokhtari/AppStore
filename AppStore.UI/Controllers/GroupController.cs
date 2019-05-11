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

            return View(sampleGroup);
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
        public ActionResult Create(Group g)
        {
            new Biz.GroupBiz().Create(g);
            return View(Get(g.Id));
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