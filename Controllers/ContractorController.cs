using AutoMapper;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Controllers
{

    [Route("/contractor")]
    public class ContractorController : ControllerBase
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContractorController(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("all")]
        public ActionResult<List<ContractorDto>> GetAll()
        {
            var contractors = _dbContext
                .Contractors
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .ToList();

            if (contractors is null)
            {
                return NotFound();
            }

            var contractorsDtos = _mapper.Map<List<ContractorDto>>(contractors);

            return Ok(contractorsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractorDto> Get([FromRoute] int id)
        {
            var contractor = _dbContext
                .Contractors
                .Include(r => r.Address)
                .Include(r => r.Contact)
                .FirstOrDefault(c => c.Id == id);

            if (contractor is null)
            {
                return NotFound();
            }

            var contractorDto = _mapper.Map<ContractorDto>(contractor);

            return Ok(contractorDto);
        }

    }
}

