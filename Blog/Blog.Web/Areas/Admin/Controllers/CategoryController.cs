using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Areas.Admin.Models;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var model =new CategoryViewModel();
            return View();
        }
    }
}