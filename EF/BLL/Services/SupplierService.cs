using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class SupplierService:ISupplierService
    {
        IUnitOfWork unit { get; set; }
        private readonly IMapper productMapper;
        private readonly IMapper categoryMapper;
        private readonly IMapper supplierMapper;


        public SupplierService(IUnitOfWork uow)
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

        public IEnumerable<SupplierDTO> GetAllSuppliersByCategoryName(string categoryName)
        {
            var products = unit.Products.FindByCondition(x => x.Category.CategoryName == categoryName);
            

            var suppliers = products.Select(x => x.Supplier);
            return supplierMapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(suppliers.ToList());
        }

        public IEnumerable<SupplierDTO> GetAllSuppliersByExpression(Expression<Func<Supplier, bool>> expression)
        {
            var suppliers = supplierMapper.Map<IEnumerable<Supplier>, List<SupplierDTO>>(
                unit.Suppliers.FindByCondition(expression).ToList()
            );
            return suppliers;
        }
    }
}
