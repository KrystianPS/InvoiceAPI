using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface IProductCategoryService
    {
        Task<int> CreateProductCategory(CreateProductCategoryDto dto);

        Task<bool> DeleteProductCategory(int id);

        List<ProductCategoryDto> GetAll();

        ProductCategoryDto GetById(int id);
    }
}