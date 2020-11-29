using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.Repositories.Article;
using Blog.Core.Repositories.ArticleCategory;

namespace Blog.Core.Services.Article
{
    public class ArticleService: IArticleService
    {
        private readonly ArticleRepository _articleRepository = new ArticleRepository();
        private readonly ArticleCategoryRepository _articleCategoryRepository = new ArticleCategoryRepository();
        
        public void AddArticle(Entities.Article article, List<int> categoryIds)
        {
            var count = _articleRepository.GetCount(a => a.Title == article.Title);

            if (count > 0)
            {
                throw new InvalidOperationException("Title Already Exists");
            }
            _articleRepository.Insert(article);

            var response = _articleRepository.GetList(a => a.Title == article.Title);
            if (response.Count>0)
            {
                foreach (var categoryId in categoryIds)
                {
                    var articleCategory = new ArticleCategory
                    {
                        CategoryId = categoryId,
                        ArticleId = response[0].Id
                    };
                    _articleCategoryRepository.Insert(articleCategory);
                }
            }
        }

        public IList<Entities.Article> ArticleList()
        {
            return _articleRepository.GetList(a=>a.IsActive==true && a.IsDeleted==false);
        }

        public Entities.Article GetArticleById(int id)
        {
            return _articleRepository.GetById(id);
        }

        public void UpdateArticle(Entities.Article article, List<int> categoryIds)
        {
            var count = _articleRepository.GetCount(a => a.Title == article.Title && a.Id != article.Id);

            if (count > 0)
            {
                throw new InvalidOperationException("Title Already Exists");
            }
            _articleRepository.Update(article);

            var response = _articleRepository.GetList(a => a.Title == article.Title);
            if (response.Count > 0)
            {
                foreach (var categoryId in categoryIds)
                {
                    var articleCategory = new ArticleCategory
                    {
                        CategoryId = categoryId,
                        ArticleId = response[0].Id
                    };
                    _articleCategoryRepository.Insert(articleCategory);
                }
            }
        }

        public void DeleteArticle(Entities.Article article)
        {
            article.IsActive = false;
            article.IsDeleted = true;
            article.UpdateDate = DateTime.UtcNow;

            _articleRepository.Update(article);
        }

        public IList<Entities.Article> GetArticles(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            Expression<Func<Entities.Article, bool>> filter = null;
            filter = x => x.IsActive == true && x.IsDeleted == false && x.Title.Contains(searchText);
            return _articleRepository.Get(
                out total,
                out totalFiltered,
                filter,
                x => x.OrderByDescending(b => b.Id),
                null,
                null,
                pageIndex,
                pageSize);
        }
    }
}
