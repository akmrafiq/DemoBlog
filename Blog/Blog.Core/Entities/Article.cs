using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Article:Common
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Author { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual IList<ArticleCategory> ArticleCategories { get; set; }
    }
}
