using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;

namespace InvoiceAPI.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDto dto);

        Task<bool> DeleteProduct(int id);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);


    }
}