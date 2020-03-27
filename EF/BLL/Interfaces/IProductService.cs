using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Linq.Expressions;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProductsByCategoryName(string categoryName);
        IEnumerable<ProductDTO> GetAllProductsBySupplierName(string supplierName);
        IEnumerable<ProductDTO> GetAllProductsByFixedPrice(int price);
        IEnumerable<ProductDTO> GetAllProductsWithMaxPrice();
        IEnumerable<ProductDTO> GetAllProductsWithMinPrice();
        IEnumerable<ProductDTO> GetProductsByExpression(Expression<Func<DAL.Entities.Product, bool>> expression);
    }
}
