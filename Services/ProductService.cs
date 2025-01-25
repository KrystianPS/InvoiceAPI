using AutoMapper;
using InvoiceAPI.DtoModels.ProductModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Exceptions;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(InvoiceAPIDbContext dbContext, IMapper mapper, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public ProductDto GetById(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.ProductCategory)
                .FirstOrDefault(c => c.Id == id);

            if (product is null)
            {
                throw new NotFoundException($"Product with Id:{id} not found");
            }
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public List<ProductDto> GetAll()
        {
            var products = _dbContext.Products
                .ToList() ?? throw new NotFoundException("No products found");

            var productsDtos = _mapper.Map<List<ProductDto>>(products);
            return productsDtos;
        }

        public async Task<int> CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);


            if (!string.IsNullOrEmpty(dto.ProductCategoryName))
            {
                _logger.LogInformation("Product Category provided is null");
                var category = _dbContext.ProductCategories
                    .FirstOrDefault(c => c.Name == dto.ProductCategoryName);

                if (category != null)
                {
                    product.ProductCategoryId = category.Id;
                    product.ProductCategory = category;
                }
                else
                {
                    _logger.LogInformation("Product category table is null");
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
            _logger.LogInformation($"Product Created with id:{product.Id}");
            return product.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id) ?? throw new NotFoundException($"Product with Id:{id} not found");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(int id, UpdateProductDto dto)
        {
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id) ?? throw new NotFoundException($"Product with Id:{id} not found");

            if (dto.UnitPriceNet != product.UnitPriceNet)
            {
                product.UnitPriceNet = dto.UnitPriceNet;
            };

            if (dto.Description is not null && dto.Description != product.Description)
            {
                product.Description = dto.Description;
            };

            await _dbContext.SaveChangesAsync();
        }

    }
}
