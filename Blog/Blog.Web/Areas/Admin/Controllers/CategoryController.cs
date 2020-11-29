using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Models;

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

        public ActionResult Add()
        {
            var model = new CategoryUpdateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Add(CategoryUpdateModel model)
        {
 
            if (ModelState.IsValid)
            {
                model.AddNewCategory();
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var model = new CategoryUpdateModel();
            model.Load(id);
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryUpdateModel model)
        {

            if (ModelState.IsValid)
            {
                model.EditCategory();
            }

            return View(model);
        }

        public ActionResult GetCategories()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new CategoryViewModel();
            var data = model.GetCategories(tableModel);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var model = new CategoryViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}