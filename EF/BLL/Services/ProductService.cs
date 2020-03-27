using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System.Linq.Expressions;
using DAL.Entities;

namespace BLL.Services
{
    public class ProductService:IProductService
    {
        IUnitOfWork unit { get; set; }
        private readonly IMapper productMapper;
        private readonly IMapper categoryMapper;
        private readonly IMapper supplierMapper;


        public ProductService(IUnitOfWork uow)
        {
            if (uow != null)
                this.unit = uow;

            MapperConfiguration configCategory = new MapperConfiguration(con =>
            {
                con.CreateMap<Category, CategoryDTO>();
                con.CreateMap<CategoryDTO, Category>();
            });
            categoryMapper = configCategory.CreateMapper();

            MapperConfiguration configSupplier = new MapperConfiguration(con =>
            {
                con.CreateMap<Supplier, SupplierDTO>();
                con.CreateMap<SupplierDTO, Supplier>();
            });
            supplierMapper = configSupplier.CreateMapper();

            MapperConfiguration configProduct = new MapperConfiguration(con =>
            {
                con.CreateMap<ProductDTO, Product>()
               .ForMember(dest => dest.Category, opt => opt.MapFrom(src => categoryMapper.Map<CategoryDTO, Category>(src.Category)))
               .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => supplierMapper.Map<SupplierDTO, Supplier>(src.Supplier)));

                con.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => categoryMapper.Map<Category, CategoryDTO>(src.Category)))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => supplierMapper.Map<Supplier, SupplierDTO>(src.Supplier)));
            });

            productMapper = configProduct.CreateMapper();


        }


        public IEnumerable<ProductDTO> GetAllProductsByCategoryName(string categoryName)
        {
            
            var result = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindByCondition(x => x.Category.CategoryName == categoryName).ToList());
            return  (result);
        }

        public IEnumerable<ProductDTO> GetAllProductsBySupplierName(string supplierName)
        {
            var products = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindByCondition(x => x.Supplier.CompanyName == supplierName).ToList()
            );
            return products;
        }

        public IEnumerable<ProductDTO> GetProductsByExpression(Expression<Func<DAL.Entities.Product, bool>> expression)
        {
            var products = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindByCondition(expression).ToList()
            );
            return products;
        }

        public IEnumerable<ProductDTO> GetAllProductsByFixedPrice(int price)
        {
            var products = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindByCondition(x => x.ProductPrice == price).ToList()
            );
            return products;
        }

        public IEnumerable<ProductDTO> GetAllProductsWithMaxPrice()
        {
            var maxPrice = unit.Products.FindAll().ToList().OrderByDescending(x => x.ProductPrice).First().ProductPrice;
            var products = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindAll().ToList().OrderByDescending(x => x.ProductPrice).TakeWhile(x => x.ProductPrice == maxPrice).ToList()
            );
            return products;
        }

        public IEnumerable<ProductDTO> GetAllProductsWithMinPrice()
        {
            var minPrice = unit.Products.FindAll().ToList().OrderBy(x => x.ProductPrice).First().ProductPrice;
            var products = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Products.FindAll().ToList().OrderBy(x => x.ProductPrice).TakeWhile(x => x.ProductPrice == minPrice).ToList()
            );
            return products;
        }
    
}
}
