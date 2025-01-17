using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.Models.ContractorModel;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{

    [Route("/contractor")]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        public ContractorController(IContractorService contractor)
        {
            _contractorService = contractor;
        }
        [HttpGet("all")]
        public ActionResult<List<ContractorDto>> GetAll()
        {
            var contractors = _contractorService.GetAll();



            return Ok(contractors);
        }

        [HttpGet("{id}")]
        public ActionResult<ContractorDto> GetById([FromRoute] int id)
        {
            var contractor = _contractorService.GetById(id);

            return Ok(contractor);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateContractorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contractorService.CreateContractor(dto);


            return Created($"contractor/{id}", null);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _contractorService.DeleteContractor(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok($"Contractor with id:{id} deleted");
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateContractorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _contractorService.UpdateContractor(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok($"Contractor with id:{id} has been updated");

        }


    }
}

