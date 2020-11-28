using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class ArticleCategory:Common
    {
        public virtual int ArticleId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
