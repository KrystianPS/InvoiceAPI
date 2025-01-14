using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;

namespace InvoiceAPI.MappingProfiles
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>()
                .ForMember(m => m.Products, pc => pc.MapFrom(p => p.Products));

            CreateMap<CreateProductCategoryDto, ProductCategory>();
        }
    }
}
