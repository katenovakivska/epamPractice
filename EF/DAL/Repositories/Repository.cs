using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Linq.Expressions;
using DAL.Context;
using System.Data.Entity;

namespace DAL.Repositories
{
    abstract class Repository<T> : IRepository<T> where T : class
    {
        protected internal ApplicationContext ApplicationContext { get; }

        public Repository(ApplicationContext context)
        {
            this.ApplicationContext = context;
        }
        public void Create(T entity)
        {
            this.ApplicationContext.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            this.ApplicationContext.Set<T>().Remove(entity);
        }
        public IEnumerable<T> FindAll()
        {

            return this.ApplicationContext.Set<T>().AsNoTracking();
        }
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationContext.Set<T>().Where(expression).AsNoTracking();
        }

    }
}
