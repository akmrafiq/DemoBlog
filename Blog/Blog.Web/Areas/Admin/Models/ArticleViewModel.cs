using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Core.Entities;
using Blog.Core.Services.Article;
using Blog.Core.Services.Category;
using Blog.Web.Models;

namespace Blog.Web.Areas.Admin.Models
{
    public class ArticleViewModel:BaseModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly IArticleService _articleService = new ArticleService();

        public IList<Article> GetArticles()
        {
            return _articleService.ArticleList();
        }

        public object GetArticles(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _articleService.GetArticles(
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
                            record.Title,
                            record.Description,
                            record.Author,
                            record.ImageUrl,
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void Delete(int id)
        {
            var article = _articleService.GetArticleById(id);
            article.IsDeleted = true;
            article.IsActive = false;
            _articleService.DeleteArticle(article);
        }
    }
}