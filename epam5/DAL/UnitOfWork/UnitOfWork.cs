using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.SqlClient;
using DAL.TDG;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlConnection _connection;
        private IProductTDG _product;
        private ISupplierTDG _supplier;
        private ICategoryTDG _category;

        public UnitOfWork(string connectionString)
        {
            this._connection = new SqlConnection(connectionString);
        }

        public IProductTDG Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductTDG(_connection);
                }
                return _product;
            }
        }

        public ICategoryTDG Category
        {
            get
            {
                if(_category == null)
                {
                    _category = new CategoryTDG(_connection);
                }
                return _category;
            }
        }

        public ISupplierTDG Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierTDG(_connection);
                }
                return _supplier;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
