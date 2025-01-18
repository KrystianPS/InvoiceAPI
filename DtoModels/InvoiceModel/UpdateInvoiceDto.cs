namespace InvoiceAPI.DtoModels.InvoiceModel
{
    public class UpdateInvoiceDto
    {

        public string? InvoiceNumber { get; set; }
        public DateTime? DueDate { get; set; }
        public string? InvoiceNote { get; set; }
        public int? ContractorId { get; set; }

        public List<CreateInvoiceItemDto>? ItemsToAdd { get; set; }

        public List<int>? ItemsToDelete { get; set; }

    }
}
