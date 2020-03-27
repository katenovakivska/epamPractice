using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProductTDG Product { get; }
        ISupplierTDG Supplier { get; } 
        ICategoryTDG Category { get; }

        void Save();
    }
}
