﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string CompanyName { get; set; }
       
    }
}
