using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/contractor")]
    public class ProductController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public ProductController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<List<ProductDto>> GetAll()
        {
            var contractors = _dbContext.Products.ToList();

            return Ok(contractors);
        }

    }
}
