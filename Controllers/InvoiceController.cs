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
        private readonly ILogger<InvoiceController> _logger;
        public InvoiceController(IInvoiceService invoiceService, InvoiceAPIDbContext dbContext, ILogger<InvoiceController> logger)
        {
            _invoiceService = invoiceService;
            _dbContext = dbContext;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateInvoiceDto dto)
        {
            _logger.LogInformation($"Create invoice query invoked");
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
            _logger.LogInformation($"Delete invoice with Id:{id} query invoked");
            await _invoiceService.DeleteInvoice(id);

            return Ok($"Invoice with id:{id} deleted");
        }


        [HttpGet("all")]
        public ActionResult<List<InvoiceDto>> GetAll()
        {
            _logger.LogInformation($"Get all invoices query invoked");
            var products = _invoiceService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<List<InvoiceDto>> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Get invoice by Id:{id} query invoked");
            var invoices = _invoiceService.GetById(id);
            return Ok(invoices);
        }

        [HttpGet("company/{id}")]
        public ActionResult GetAllByCompanyId([FromRoute] int id)
        {
            _logger.LogInformation($"Get invoices by company Id:{id} query invoked");
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
            _logger.LogInformation($"Get invoics by contractor Id:{id} query invoked");
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
            _logger.LogInformation($"Update invoice with Id:{id} query invoked");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _invoiceService.UpdateInvoice(id, dto);

            return Ok($"Company with id:{id} has been updated");

        }

    }
}