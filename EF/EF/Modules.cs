using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;

namespace EF
{
    public class Modules:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<ISupplierService>().To<SupplierService>();
        }
    }
}
