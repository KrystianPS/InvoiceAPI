namespace InvoiceAPI.Models
{
    public class CreateContractorDto
    {
        public string Name { get; set; }
        public int? TIN { get; set; }
        public string EmailAdress { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddresLine1 { get; set; }
        public string AddresLine2 { get; set; }
        public string PostalCode { get; set; }
        public int CompanyId { get; set; }

    }
}
