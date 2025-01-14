using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ProductDto GetById(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.ProductCategory)
                .FirstOrDefault(c => c.Id == id);

            if (product is null)
            {
                return null;
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public List<ProductDto> GetAll()
        {
            var products = _dbContext.Products
                .ToList();
            if (products is null)
            {
                return null;
            }

            var productsDtos = _mapper.Map<List<ProductDto>>(products);
            return productsDtos;
        }

        public async Task<int> CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);


            if (!string.IsNullOrEmpty(dto.ProductCategoryName))
            {

                var category = _dbContext.ProductCategories
                    .FirstOrDefault(c => c.Name == dto.ProductCategoryName);

                if (category != null)
                {

                    product.ProductCategoryId = category.Id;
                    product.ProductCategory = category;
                }
                else
                {

                    product.ProductCategoryId = null;
                    product.ProductCategory = null;
                }
            }
            else
            {

                product.ProductCategoryId = null;
                product.ProductCategory = null;
            }

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product is null) return false;

            _dbContext.Products.Remove(product);
            _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
