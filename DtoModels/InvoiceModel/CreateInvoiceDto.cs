using InvoiceAPI.DtoModels.InvoiceModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.InvoiceModel
{
    public class CreateInvoiceDto
    {
        public string? InvoiceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string InvoiceNote { get; set; }
        [Required]
        public required int CompanyId { get; set; }
        [Required]
        public required int ContractorId { get; set; }
        [Required]
        public List<CreateInvoiceItemDto> InvoiceItems { get; set; } = new List<CreateInvoiceItemDto>();
    }
}
