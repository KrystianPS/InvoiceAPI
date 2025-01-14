using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface IProductCategoryService
    {
        Task<int> CreateProductCategory(CreateProductCategoryDto dto);

        List<ProductCategoryDto> GetAll();

        ProductCategoryDto GetById(int id);
    }
}