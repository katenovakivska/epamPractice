using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Context;
using DAL.Repositories;

using DAL.Entities;

namespace DAL.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationContext applicationContext;
        private ProductRepository product;
        private SupplierRepository supplier;
        private CategoryRepository category;

        public UnitOfWork(string connectionString)
        {
            this.applicationContext = new ApplicationContext(connectionString);
        }
        public IProductRepository Products
        {
            get
            {
                if (product == null)
                {
                    product = new ProductRepository(applicationContext);
                }
                return product;
            }
        }

        public ISupplierRepository Suppliers
        {
            get
            {
                if (supplier == null)
                {
                    supplier = new SupplierRepository(applicationContext);
                }
                return supplier;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                if (category == null)
                {
                    category = new CategoryRepository(applicationContext);
                }
                return category;
            }
        }

        public void Save()
        {
            this.applicationContext.SaveChanges();
        }
    }
}
