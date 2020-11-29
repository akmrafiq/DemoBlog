using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Areas.Admin.Models;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Admin/Article
        public ActionResult Index()
        {
            var model =new  ArticleViewModel();
            var articles = model.GetArticles();
            return View(articles);
        }
    }
}