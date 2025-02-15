using InvoiceAPI.Application.Services.Repositories;
using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Models.CompanyModel;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;


        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet("all")]

        public ActionResult<List<CompanyDto>> GetAll()
        {
            var companies = _companyService.GetAll();

            return Ok(companies);
        }


        [HttpGet("{id}")]
        public ActionResult<CompanyDto> Get([FromRoute] int id)
        {
            var company = _companyService.GetById(id);

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCompanyDto dto)
        {
            _logger.LogInformation($"Create company query invoked");

            var id = await _companyService.CreateCompany(dto);
            return Created($"company/{id}", dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Delete company with Id:{id} query invoked");
            await _companyService.DeleteCompany(id);

            return Ok($"Company with id:{id} deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyDto dto)
        {
            _logger.LogInformation($"Update company with Id:{id} query invoked");

            await _companyService.UpdateCompany(id, dto);

            return Ok($"Company with id:{id} updated");

        }
    }
}
