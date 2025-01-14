using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;

namespace InvoiceAPI.MappingProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductDto, Product>();
        }


    }
}
