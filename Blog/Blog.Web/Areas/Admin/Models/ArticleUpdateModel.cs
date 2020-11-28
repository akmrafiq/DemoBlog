using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Core.Entities;
using Blog.Core.Services.Article;
using Blog.Core.Services.Category;

namespace Blog.Web.Areas.Admin.Models
{
    public class ArticleUpdateModel:BaseModel
    {
        private readonly IArticleService _articleService = new ArticleService();
        private readonly ICategoryService _categoryService = new CategoryService();

        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        public virtual string Title { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please Enter Description")]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Author Name")]
        public virtual string Author { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual List<int> CategoryIds { get; set; }

        public void AddNewCategory()
        {
            try
            {
                var article = new Article
                {
                    Title = this.Title,
                    Description = this.Description,
                    Author = this.Author,
                    ImageUrl = this.ImageUrl
                };
                _articleService.AddArticle(article,CategoryIds);

                Notification = new NotificationModel("Success!", "Article successfully created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create article, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create article, please try again",
                    NotificationType.Fail);
            }
        }
    }
}