using AutoMapper;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Controllers
{
    [Route("/company")]
    public class CompanyController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;


        public CompanyController(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        [HttpGet("all")]

        public ActionResult<List<CompanyDto>> GetAll()
        {
            var companies = _dbContext
                .Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .ToList();

            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies);
            return Ok(companiesDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<CompanyDto> Get([FromRoute] int id)
        {


            var company = _dbContext.Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .FirstOrDefault(c => c.Id == id);
            if (company is null)
            {
                return NotFound();
            }


            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }
    }
}
