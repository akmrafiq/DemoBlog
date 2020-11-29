using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Core.Config.Mappings
{
    public class ArticleMapping:ClassMap<Article>
    {
        public ArticleMapping()
        {
            Table("Article");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title).Not.Nullable();
            Map(x => x.Description).Not.Nullable().Length(20000);
            Map(x => x.Author).Not.Nullable();
            Map(x => x.ImageUrl).Nullable();
            Map(x => x.IsActive);
            Map(x => x.IsDeleted);
            Map(x => x.CreateDate).Nullable();
            Map(x => x.UpdateDate).Nullable();
        }
    }
}
