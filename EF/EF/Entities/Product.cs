﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int CategoryID { get; set; }

        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}