using Blog.Core.Services.Category;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Areas.Admin.Models
{
    public class CategoryViewModel:BaseModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        public object GetCategories(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _categoryService.GetCategories(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                            record.Name,
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            category.IsDeleted = true;
            category.IsActive = false;
            _categoryService.DeleteCategory(category);
        }
    }
}