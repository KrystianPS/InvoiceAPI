namespace InvoiceAPI.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public VatRate VatRate { get; set; }
        public int VatId { get; set; }
        public decimal VatRateThreshold { get; set; }

        public decimal TotalNet { get; set; }
        public decimal TotalVatAmount { get; set; }
        public decimal TotalGross { get; set; }
        public string InvoiceNote { get; set; }

        public int InvoiceItemsCount => InvoiceItems.Count;

        public required int CompanyId { get; set; }
        public Company Company { get; set; }
        public required int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    }
}
