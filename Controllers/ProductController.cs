using InvoiceAPI.DtoModels.ProductModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet("all")]
        public ActionResult<List<ProductDto>> GetAll()
        {
            _logger.LogInformation("Get all products query invoked");
            var products = _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<List<ProductDto>> GetById(int id)
        {
            _logger.LogInformation($"Get by id:{id} product query invoked");
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto dto)
        {
            _logger.LogInformation("Create product query invoked");

            var id = await _productService.CreateProduct(dto);

            return Created($"product/{id}", null);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto dto)
        {
            _logger.LogInformation($"Update product with Id:{id} query invoked");

            await _productService.UpdateProduct(id, dto);

            return Ok($"Product with id:{id} updated");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Delete product with Id:{id} query invoked");
            await _productService.DeleteProduct(id);

            return Ok($"Product with id:{id} deleted");
        }


    }
}
