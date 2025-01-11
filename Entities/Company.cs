namespace InvoiceAPI.Entities
{
    public class Company

    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TIN { get; set; }
        public required virtual CompanyAddressDetails Address { get; set; }
        public required virtual CompanyContactDetails Contact { get; set; }

        public List<Contractor> Contractors { get; set; } = new List<Contractor>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Product> Products { get; set; } = new List<Product>();


    }
}
