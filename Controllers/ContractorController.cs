using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("api/contractor")]
    public class ContractorController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public ContractorController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<List<CompanyDto>> GetAll()
        {
            var contractors = _dbContext.Contractors.ToList();

            return Ok(contractors);
        }

    }
}

