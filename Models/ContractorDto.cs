namespace InvoiceAPI.Models
{
    public class ContractorDto
    {


        public required string Name { get; set; }
        public int? TIN { get; set; }
        public required string EmailAdress { get; set; }
        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string AddresLine1 { get; set; }
        public required string AddresLine2 { get; set; }
        public required string PostalCode { get; set; }
        public int CompanyId { get; set; }


    }
}
