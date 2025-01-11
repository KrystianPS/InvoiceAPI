namespace InvoiceAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public int? TIN { get; set; }
        public virtual ContractorAddressDetails? Address { get; set; }
        public virtual ContractorContactDetails? Contact { get; set; }



        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
