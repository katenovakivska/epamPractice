using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;

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
            var supplierProducts = productMapper.Map<IEnumerable<Product>, List<ProductDTO>>(    
                unit.Product.GetAll().Where(x => x.Category.CategoryName == categoryName).ToList()
            );
            var result = supplierProducts.Select(x => x.Supplier).Distinct().ToList();
            return result;
        }
          
    }
}
