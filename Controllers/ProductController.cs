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
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("all")]
        public ActionResult<List<ProductDto>> GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<List<ProductDto>> GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto dto)
        {

            if (!ModelState.IsValid)
            {
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
                return NotFound();
            }
            return Ok($"Product with id:{id} deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _productService.UpdateProduct(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok($"Product with id:{id} updated");
        }



    }
}
