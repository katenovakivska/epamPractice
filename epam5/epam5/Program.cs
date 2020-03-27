using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;
using Ninject.Modules;
using BLL.Infrastructura;
using Ninject;

namespace epam5
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ProductCatalog;Integrated Security=True";
            NinjectModule storeModule = new Modules();
            NinjectModule serviceModule = new ServiceModule(connectionString);
            var kernel = new StandardKernel(storeModule, serviceModule);

            var productService = kernel.Get<IProductService>();
            var supplierService = kernel.Get<ISupplierService>();


            Console.WriteLine();
            Console.WriteLine("Print products with fixed price = 38");
            PrintProductsByFixedPrice(productService, 38);

            Console.WriteLine();
            Console.WriteLine("Print product with the name Dolce");
            PrintProductsBySupplier(productService, "Dolce");

            Console.WriteLine();
            Console.WriteLine("Print product with the name fruit");
            PrintProductsByCategory(productService, "fruit");

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Print suppliers with the name of category 'vegetable'");
            PrintSupplierByCategory(supplierService, "vegetable");

            Console.WriteLine();
            Console.WriteLine("Print products with max price");
            PrintProductsByMaxPrice(productService);
            Console.WriteLine("Print products with min price");
            PrintProductsByMinPrice(productService);

            Console.ReadKey();

        }
        static void PrintProductsByFixedPrice(IProductService productService, int price)
        {
            var productsWithFixedPrice = productService.GetAllProductByProductPrice(price);

            foreach (var product in productsWithFixedPrice)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductID, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName, product.Price);
        }

        static void PrintProductsBySupplier(IProductService productService, string supplier)
        {
            var productsBySupplier = productService.GetAllProductsByCompanyName(supplier);

            foreach (var product in productsBySupplier)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductID, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName, product.Price);
        }

        static void PrintProductsByCategory(IProductService productService, string category)
        {
            var productsByCategory = productService.GetAllProductsByCategoryName(category);

            foreach (var product in productsByCategory)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductID, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName, product.Price);
        }


        static void PrintSupplierByCategory(ISupplierService supplierService, string categoryName)
        {
            var suppliers = supplierService.GetAllSuppliersByCategoryName(categoryName);
            foreach (var supplier in suppliers)
                Console.WriteLine("SupplierId: {0}, supplierName: {1}", supplier.SupplierID, supplier.CompanyName);
        }

        static void PrintProductsByMaxPrice(IProductService productService)
        {
            var products = productService.GetProductsWithMaxPrice();
            foreach (var product in products)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductID, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName, product.Price);
        }
        static void PrintProductsByMinPrice(IProductService productService)
        {
            var products = productService.GetProductsWithMinPrice();
            foreach (var product in products)
                Console.WriteLine("ProductId: {0}, ProductName: {1}, Category: {2}, Supplier: {3}, ProductPrice: {4}", product.ProductID, product.ProductName, product.Category.CategoryName, product.Supplier.CompanyName, product.Price);
        }

    }
}
