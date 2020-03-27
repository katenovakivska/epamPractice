using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Context;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    class SupplierRepository:Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationContext applicationContext)
             : base(applicationContext)
        {
        }
    }
}
