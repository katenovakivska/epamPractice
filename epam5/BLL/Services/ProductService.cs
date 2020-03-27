
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Models;

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
                unit.Product.GetAll().Where(x => x.Category.CategoryName == categoryName).ToList()
            );
            return result;
        }

        public IEnumerable<ProductDTO> GetAllProductsByCompanyName(string companyName)
        {
            if (companyName != null)
            {
                var result = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                    unit.Product.GetAll().Where(x => x.Supplier.CompanyName == companyName).ToList()
                    );
                return result;
            }
            else return null;
        }

        public IEnumerable<ProductDTO> GetAllProductByProductPrice(int price)
        {
            var result = productMapper.Map<IEnumerable<Product>,List<ProductDTO>>(
                unit.Product.GetAll().Where(x => x.Price == price).ToList()
                );
                return result;
        }

        public IEnumerable<ProductDTO> GetProductsWithMaxPrice()
        {
            var maxPrice = unit.Product.GetAll().OrderByDescending(x => x.Price).First();
            var result = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Product.GetAll().ToList().OrderByDescending(x => x.Price).TakeWhile(x => x.Price == maxPrice.Price)
                );
            return result;
        }

        public IEnumerable<ProductDTO> GetProductsWithMinPrice()
        {
            var maxPrice = unit.Product.GetAll().OrderBy(x => x.Price).First();
            var result = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(
                unit.Product.GetAll().ToList().OrderBy(x => x.Price).TakeWhile(x => x.Price == maxPrice.Price)
                );
            return result;
        }
    }
}
