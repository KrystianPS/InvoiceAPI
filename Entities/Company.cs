namespace InvoiceAPI.Entities
{
    public class Company

    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TIN { get; set; }
        public required CompanyAddressDetails AddressDetails { get; set; }
        public required CompanyContactDetails ContactDetails { get; set; }

        public List<Contractor> Contractors { get; set; } = new List<Contractor>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Product> Products { get; set; } = new List<Product>();


    }
}
