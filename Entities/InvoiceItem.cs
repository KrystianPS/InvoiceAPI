namespace InvoiceAPI.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }

        public int Quantity { get; set; }
        public decimal ItemPriceNet { get; set; }

        public decimal VatRate { get; set; }
        public decimal ItemVatAmount { get; set; }
        public decimal ItemPriceGross { get; set; }
    }
}