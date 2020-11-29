using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;

namespace Blog.Core.Services.Article
{
    public interface IArticleService
    {
        IList<Entities.Article> GetArticles(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered);
        void AddArticle(Entities.Article article, List<int> categoryIds);
        IList<Entities.Article> ArticleList();
        Entities.Article GetArticleById(int id);
        void UpdateArticle(Entities.Article article, List<int> categoryIds);
        void DeleteArticle(Entities.Article article);
    }
}
