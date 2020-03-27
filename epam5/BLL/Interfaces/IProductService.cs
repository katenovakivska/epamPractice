using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProductsByCategoryName(string categoryName);
        IEnumerable<ProductDTO> GetAllProductsByCompanyName(string companyName);
        IEnumerable<ProductDTO> GetAllProductByProductPrice(int price);
        IEnumerable<ProductDTO> GetProductsWithMaxPrice();

        IEnumerable<ProductDTO> GetProductsWithMinPrice();
    }
}
