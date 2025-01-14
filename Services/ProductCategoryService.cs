using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductCategoryService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<ProductCategoryDto> GetAll()
        {
            var categories = _dbContext.ProductCategories
                .Include(x => x.Products)
                .ToList();
            if (categories is null)
            {
                return null;
            }

            var categoriesDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
            return categoriesDtos;
        }

        public ProductCategoryDto GetById(int id)
        {
            var category = _dbContext.ProductCategories
                .Include(x => x.Products)
                .Include(pc => pc.Products)
                .FirstOrDefault();
            if (category is null)
            {
                return null;
            }

            var productCategoryDto = _mapper.Map<ProductCategoryDto>(category);
            return productCategoryDto;
        }

        public async Task<int> CreateProductCategory(CreateProductCategoryDto dto)
        {
            var category = _mapper.Map<ProductCategory>(dto);

            _dbContext.ProductCategories.Add(category);
            await _dbContext.SaveChangesAsync();

            return category.Id;

        }
    }
}
