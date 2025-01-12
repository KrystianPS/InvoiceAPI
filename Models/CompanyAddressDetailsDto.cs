namespace InvoiceAPI.Models
{
    public class CompanyAddressDetailsDto
    {
        public required string City { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string PostalCode { get; set; }
    }
}