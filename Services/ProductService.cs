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
            _logger.LogInformation("---Get Product with id:{id} query invoked---", id);
            var product = _dbContext.Products
                .Include(c => c.ProductCategory)
                .FirstOrDefault(c => c.Id == id);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public List<ProductDto> GetAll()
        {
            _logger.LogInformation("---Get All Products query invoked---");
            var products = _dbContext.Products
                .ToList();
            if (products is null)
            {
                throw new NotFoundException("Products not found");
            }

            var productsDtos = _mapper.Map<List<ProductDto>>(products);
            return productsDtos;
        }

        public async Task<int> CreateProduct(CreateProductDto dto)
        {
            _logger.LogInformation("---Create product query invoked---");
            var product = _mapper.Map<Product>(dto);


            if (!string.IsNullOrEmpty(dto.ProductCategoryName))
            {
                _logger.LogInformation("---Product Category is null---");
                var category = _dbContext.ProductCategories
                    .FirstOrDefault(c => c.Name == dto.ProductCategoryName);

                if (category != null)
                {
                    _logger.LogInformation("---Product category table is null---");
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
            _logger.LogInformation("---Product Created with id:{Id}---", product.Id);
            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            _logger.LogInformation("---Delete product with id:{id} invoked---", id);
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product is null) throw new NotFoundException("Product not found");

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(int id, UpdateProductDto dto)
        {
            _logger.LogInformation("---Update product with id:{id} invoked---", id);
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product is null) throw new NotFoundException("Product not found");

            if (dto.UnitPriceNet != product.UnitPriceNet)
            {
                product.UnitPriceNet = dto.UnitPriceNet;
            };

            if (dto.Description is not null && dto.Description != product.Description)
            {
                product.Description = dto.Description;
            };

            _dbContext.SaveChanges();
        }

    }
}
