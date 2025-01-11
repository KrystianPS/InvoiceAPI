using InvoiceAPI.Entities;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public CompanyController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<List<Company>> GetAll()
        {
            var companies = _dbContext.Companies.ToList();

            return Ok(companies);
        }

    }
}
