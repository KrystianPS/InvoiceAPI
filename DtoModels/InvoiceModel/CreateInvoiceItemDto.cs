namespace InvoiceAPI.DtoModels.InvoiceModel
{
    public class CreateInvoiceItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal VatRate { get; set; }
    }
}
