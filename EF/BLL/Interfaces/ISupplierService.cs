using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Linq.Expressions;

namespace BLL.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetAllSuppliersByCategoryName(string categoryName);
        IEnumerable<SupplierDTO> GetAllSuppliersByExpression(Expression<Func<DAL.Entities.Supplier, bool>> expression);
    }
}
