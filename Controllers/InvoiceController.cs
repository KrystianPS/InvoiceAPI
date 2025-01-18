using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Models.InvoiceModel;
using InvoiceAPI.Persistance;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly InvoiceAPIDbContext _dbContext;
        public InvoiceController(IInvoiceService invoiceService, InvoiceAPIDbContext dbContext)
        {
            _invoiceService = invoiceService;
            _dbContext = dbContext;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateInvoiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var invoiceId = await _invoiceService.CreateInvoice(dto);
                return Created($"invoice/{invoiceId}", null);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _invoiceService.DeleteInvoice(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok($"Invoice with id:{id} deleted");
        }




        [HttpGet("all")]
        public ActionResult<List<InvoiceDto>> GetAll()
        {
            var products = _invoiceService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<List<InvoiceDto>> GetById([FromRoute] int id)
        {
            var invoices = _invoiceService.GetById(id);
            return Ok(invoices);
        }

        [HttpGet("company/{id}")]
        public ActionResult GetAllByCompanyId([FromRoute] int id)
        {
            var invoices = _invoiceService.GetAllByCompanyId(id);
            if (invoices == null || !invoices.Any())
            {
                return NotFound($"No invoices found for company with ID {id}");
            }
            return Ok(invoices);
        }

        [HttpGet("contractor/{id}")]
        public ActionResult GetAllByContractorId([FromRoute] int id)
        {
            var invoices = _invoiceService.GetAllByContractorId(id);
            if (invoices == null || !invoices.Any())
            {
                return NotFound($"No invoices found for contractor with ID {id}");
            }
            return Ok(invoices);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateInvoiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _invoiceService.UpdateInvoice(id, dto);

            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok($"Company with id:{id} has been updated");

        }

    }
}