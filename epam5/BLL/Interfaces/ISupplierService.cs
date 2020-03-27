using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetAllSuppliersByCategoryName(string categoryName);
    }
}
