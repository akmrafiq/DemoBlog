using Blog.Core.Services.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Core.Entities;

namespace Blog.Web.Areas.Admin.Models
{
    public class CategoryUpdateModel:BaseModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();

        public int Id { get; set; }
        public string Name { get; set; }


        public void AddNewCategory()
        {
            try
            {
                _categoryService.AddCategory(new Category
                {
                    Name = this.Name,
                });

                Notification = new NotificationModel("Success!", "Category successfully created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }


        public void Load(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }

        public void EditCategory()
        {
            try
            {
                var currentCategory = _categoryService.GetCategoryById(Id);
                _categoryService.UpdateCategory(new Category
                {
                    Id = this.Id,
                    Name = this.Name,
                });

                Notification = new NotificationModel("Success!", "Category successfully updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please try again",
                    NotificationType.Fail);
            }
        }
    }
}