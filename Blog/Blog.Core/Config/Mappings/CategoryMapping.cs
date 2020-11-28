using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using FluentNHibernate.Mapping;

namespace Blog.Core.Config.Mappings
{
    public class CategoryMapping:ClassMap<Category>
    {
        public CategoryMapping()
        {
            Table("Category");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.IsActive);
            Map(x => x.IsDeleted);
            Map(x => x.CreateDate).Nullable();
            Map(x => x.UpdateDate).Nullable();
        }
    }
}
