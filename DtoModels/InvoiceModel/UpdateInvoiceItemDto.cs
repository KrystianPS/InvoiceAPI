using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.DtoModels.InvoiceModel
{
    public class UpdateInvoiceItemDto
    {
        [Required]
        public required int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? VatRate { get; set; }
    }
}
