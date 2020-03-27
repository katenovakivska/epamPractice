using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public virtual SupplierDTO Supplier { get; set; }
        public virtual CategoryDTO Category { get; set; }
    }
}
