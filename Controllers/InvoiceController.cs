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

        [HttpGet("all")]
        public ActionResult<List<InvoiceDto>> GetAll()
        {
            var products = _invoiceService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<List<InvoiceDto>> GetById(int id)
        {
            var invoices = _invoiceService.GetById(id);
            return Ok(invoices);
        }
    }
}
