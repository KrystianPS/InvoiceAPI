namespace InvoiceAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? TIN { get; set; }
        public ContractorAddressDetails? AddressDetails { get; set; }
        public ContractorContactDetails? ContactDetails { get; set; }


        public List<Company> Companies { get; set; } = new List<Company>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
