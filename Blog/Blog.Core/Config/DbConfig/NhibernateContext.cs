using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Config.Mappings;

namespace Blog.Core.Config.DbConfig
{
    public class NhibernateContext
    {
        private static ISessionFactory _session;

        private static ISessionFactory CreateSession()
        {
            if (_session != null)
            {
                return _session;
            }

            FluentConfiguration config = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c
                        .Server(@"DESKTOP-RC6D932\SQLEXPRESS")
                        .Username("Test")
                        .Password("Test@123")
                        .Database("Blog")))

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArticleMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMapping>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ArticleCategoryMapping>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            _session = config.BuildSessionFactory();

            return _session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
