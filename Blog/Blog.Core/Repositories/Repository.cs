using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Config.DbConfig;
using NHibernate;

namespace Blog.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public void Insert(T entity)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }

                        throw new Exception(ex.Message);
                    }
                }

            }
        }

        public void Update(T entity)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }

                        throw new Exception(ex.Message);
                    }
                }

            }
        }

        public void Delete(T entity)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entity);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                        {
                            _transaction.Rollback();
                        }

                        throw new Exception(ex.Message);
                    }
                }

            }
        }

        public T GetById(int id)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {
                return _session.Get<T>(id);
            }
        }

        public IList<T> GetList()
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {

                return _session.Query<T>().ToList();
            }
        }

        public int GetCount(Expression<Func<T, bool>> predicate = null)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {

                var count = _session.Query<T>()
                    .Where(predicate)
                    .Count();

                return count;
            }
        }

        public IList<T> GetList(Expression<Func<T, bool>> predicate = null)
        {
            using (ISession _session = NhibernateContext.SessionOpen())
            {

                var list = _session.Query<T>()
                    .Where(predicate)
                    .ToList();

                return list;
            }
        }
    }
}
