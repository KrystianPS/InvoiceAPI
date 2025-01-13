using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(CreateProductDto dto);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
    }
}