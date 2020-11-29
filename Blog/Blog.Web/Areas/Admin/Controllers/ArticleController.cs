using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Models;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Admin/Article/GetArticles
        public ActionResult Index()
        {
            var model =new  ArticleViewModel();
            var articles = model.GetArticles();
            return View();
        }

        public ActionResult GetArticles()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ArticleViewModel();
            var data = model.GetArticles(tableModel);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var model = new ArticleViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}