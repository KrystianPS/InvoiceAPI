namespace InvoiceAPI.DtoModels.InvoiceModel
{
    public class InvoiceItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPriceNet { get; set; }
        public decimal VatRate { get; set; }
        public decimal ItemVatAmount { get; set; }
        public decimal ItemPriceGross { get; set; }
    }
}
