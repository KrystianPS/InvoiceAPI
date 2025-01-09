namespace InvoiceAPI.Entities
{
    public class Contractor
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? TIN { get; set; }
        public ContractorAddressDetails? AddressDetails { get; set; }
        public ContractorContactDetails? ContactDetails { get; set; }

    }
}
