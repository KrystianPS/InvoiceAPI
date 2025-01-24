using InvoiceAPI.DtoModels.ProductModel;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;

namespace InvoiceAPI.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDto dto);
        void UpdateProduct(int id, UpdateProductDto dto);
        void DeleteProduct(int id);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);


    }
}