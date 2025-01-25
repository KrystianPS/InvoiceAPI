using InvoiceAPI.DtoModels.ProductModel;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;

namespace InvoiceAPI.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDto dto);
        Task UpdateProduct(int id, UpdateProductDto dto);
        Task DeleteProduct(int id);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);


    }
}