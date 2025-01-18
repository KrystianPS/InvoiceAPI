using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Models.CompanyModel;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("/company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;


        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _companyService.CreateCompany(dto);
            return Created($"company/{id}", dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _companyService.DeleteCompany(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok($"Company with id:{id} deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateCompanyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _companyService.UpdateCompany(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok($"Company with id:{id} has been updated");

        }
    }
}
