using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam5.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        public float Price { get; set; }

        public Supplier Supplier { get; set; }

        public Category Category { get; set; }

    }
}
