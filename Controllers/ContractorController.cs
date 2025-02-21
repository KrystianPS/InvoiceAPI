using InvoiceAPI.Application.Services.Repositories;
using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.Models.ContractorModel;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("api/contractor")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        private readonly ILogger<ContractorController> _logger;
        public ContractorController(IContractorService contractor, ILogger<ContractorController> logger)
        {
            _contractorService = contractor;
            _logger = logger;
        }
        [HttpGet("all")]
        public ActionResult<List<ContractorDto>> GetAll()
        {
            _logger.LogInformation("Get all constractors query invoked");
            var contractors = _contractorService.GetAll();
            return Ok(contractors);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractorDto> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Get constractor with Id:{id} query invoked");
            var contractor = _contractorService.GetByIdAsync(id);
            return Ok(contractor);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateContractorDto dto)
        {
            _logger.LogInformation($"Create constractor query invoked");

            var id = _contractorService.CreateContractor(dto);
            return Created($"contractor/{id}", null);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateContractorDto dto)
        {
            _logger.LogInformation($"Update constractor with Id:{id} query invoked");

            await _contractorService.UpdateContractor(id, dto);
            return Ok($"Contractor with id:{id} has been updated");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Delete constractor with Id:{id} query invoked");
            await _contractorService.DeleteContractor(id);
            return Ok($"Contractor with id:{id} deleted");
        }


    }
}

