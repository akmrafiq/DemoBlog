using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories.Article
{
    public class ArticleRepository:Repository<Entities.Article>, IArticleRepository
    {
    }
}
