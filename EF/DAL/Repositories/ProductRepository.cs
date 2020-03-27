using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Context;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL.Repositories
{
    class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }

        public new IEnumerable<Product> FindAll()
        {
            return this.ApplicationContext.Set<Product>().Include(x => x.Category).Include(x => x.Supplier).AsNoTracking();
        }

        public new IEnumerable<Product> FindByCondition(Expression<Func<Product, bool>> expression)
        {
            return this.ApplicationContext.Set<Product>().Include(x => x.Category).Include(x => x.Supplier).Where(expression).AsNoTracking();
        }
    }
}
