using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class ArticleCategory
    {
        public virtual int ArticleId { get; set; }
        public virtual int CategoryId { get; set; }
    }
}
