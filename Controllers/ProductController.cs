using InvoiceAPI.DtoModels.ProductModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Models.ProductModel;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("/product")]
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
            _logger.LogInformation("Get by id:{id} product query invoked", id);
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto dto)
        {
            _logger.LogInformation("Create product query invoked");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Dto model is not valid");
                return BadRequest(ModelState);
            }

            var id = await _productService.CreateProduct(dto);

            return Created($"product/{id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _productService.DeleteProduct(id);

            if (!isDeleted)
            {
                _logger.LogWarning("Product with id:{id} is not deleted", id);
                return NotFound();
            }
            return Ok($"Product with id:{id} deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Update model provided is not valid");
                return BadRequest(ModelState);
            }

            var isUpdated = await _productService.UpdateProduct(id, dto);

            if (!isUpdated)
            {
                _logger.LogWarning("Product with id:{id} is not updated", id);
                return NotFound();
            }
            return Ok($"Product with id:{id} updated");
        }



    }
}
