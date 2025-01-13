using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public ProductController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("all")]
        public ActionResult<List<ProductDto>> GetAll()
        {
            var contractors = _dbContext.Products.ToList();

            return Ok(contractors);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductDto product)
        {

        }



    }
}
