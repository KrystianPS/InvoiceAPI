using InvoiceAPI.Models.ContractorModel;

namespace InvoiceAPI.Models.CompanyModel
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TIN { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Phone { get; set; }
        public required string EmailAddress { get; set; }

        public List<ContractorSummaryDto> Contractors { get; set; }
    }
}