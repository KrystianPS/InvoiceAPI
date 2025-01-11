using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/contractor")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public InvoiceController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public ActionResult<List<InvoiceDto>> GetAll()
        //{
        //    var invoices = _dbContext.Invoices.ToList();

        //    return Ok(invoices);
        //}

    }
}
