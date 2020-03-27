using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public  class ProductDTO
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        public int Price { get; set; }

        public SupplierDTO Supplier { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
