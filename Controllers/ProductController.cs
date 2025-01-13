using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Controllers
{
    [Route("/product")]
    public class ProductController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductController(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("all")]
        public ActionResult<List<ProductDto>> GetAll()
        {
            var products = _dbContext.Products
                .ToList();
            var productsDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productsDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<List<ProductDto>> GetById(int id)
        {
            var product = _dbContext.Products
                .Include(c => c.ProductCategory)
                .FirstOrDefault(c => c.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto dto)
        {
            // Mapowanie DTO do obiektu Product
            var product = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                UnitPriceNet = dto.UnitPriceNet,
                ProductCategoryName = dto.ProductCategoryName,
                CompanyId = dto.CompanyId
            };

            // Sprawdzamy, czy ProductCategoryName nie jest null i nie jest pusty
            if (!string.IsNullOrEmpty(dto.ProductCategoryName))
            {
                // Pobieramy kategorię produktu z bazy danych na podstawie nazwy
                var category = await _dbContext.ProductCategories
                    .FirstOrDefaultAsync(c => c.Name == dto.ProductCategoryName);

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

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


    }
}
