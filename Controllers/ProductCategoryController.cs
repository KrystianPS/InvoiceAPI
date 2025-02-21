using InvoiceAPI.Application.Services.Repositories;
using InvoiceAPI.Entities;
using InvoiceAPI.Models.ProductCategoryModel;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {

        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet("all")]
        public ActionResult<List<ProductCategoryDto>> GetAll()
        {
            var categories = _productCategoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductCategoryDto> GetById(int id)
        {
            var category = _productCategoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Create([FromBody] CreateProductCategoryDto dto)
        {

            var id = await _productCategoryService.CreateProductCategory(dto);

            return Created($"category/{id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _productCategoryService.DeleteProductCategory(id);

            return Ok($"Product Category with id:{id} deleted");
        }
    }
}
