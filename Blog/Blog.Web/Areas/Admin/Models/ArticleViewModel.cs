using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Core.Entities;
using Blog.Core.Services.Article;
using Blog.Core.Services.Category;

namespace Blog.Web.Areas.Admin.Models
{
    public class ArticleViewModel:BaseModel
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly IArticleService _articleService = new ArticleService();

        public IList<Category> GetAllCategory()
        {
            return _categoryService.CategoryList();
        }

        public IList<Article> GetArticles()
        {
            return _articleService.ArticleList();
        }

        public int GetArticleCount()
        {
            return _articleService.ArticleList().Count();
        }
    }
}