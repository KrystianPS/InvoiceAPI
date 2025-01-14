using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("/category")]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _productCategoryService.CreateProductCategory(dto);

            return Created($"category/{id}", null);
        }
    }
}
