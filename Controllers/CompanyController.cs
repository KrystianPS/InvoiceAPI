using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("/company")]
    public class CompanyController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public CompanyController(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("all")]
        //public ActionResult<List<CompanyDto>> GetAll()
        //{
        //    var companies = _dbContext.Companies.ToList();

        //    var companiesDtos =

        //    });

        //    return Ok(companiesDtos);
        //}

        [HttpGet("{id}")]
        public ActionResult<CompanyDto> Get([FromRoute] int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.Id == id);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
