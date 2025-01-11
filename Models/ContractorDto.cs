namespace InvoiceAPI.Models
{
    public class ContractorDto
    {


        public required string Name { get; set; }
        public int? TIN { get; set; }
        public string? EmailAdress { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? AddresLine1 { get; set; }
        public string? AddresLine2 { get; set; }
        public string? PostalCode { get; set; }
        public int CompanyId { get; set; }


    }
}
