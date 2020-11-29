using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Core.Config.Mappings
{
    public class ArticleCategoryMapping:ClassMap<ArticleCategory>
    {
        public ArticleCategoryMapping()
        {
            Table("ArticleCategory");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.IsActive);
            Map(x => x.IsDeleted);
            Map(x => x.CreateDate).Nullable();
            Map(x => x.UpdateDate).Nullable();
         
            References(x => x.Article)
                .Column("ArticleId").Not.Nullable();

            References(x => x.Category)
                .Column("CategoryId").Not.Nullable();
        }
    }
}
