namespace InvoiceAPI.Models
{
    public class ContractorSummaryDto
    {
        public required string Name { get; set; }
        public int ContractorId { get; set; }
        public int? TIN { get; set; }
        public int CompanyId { get; set; }
    }
}
