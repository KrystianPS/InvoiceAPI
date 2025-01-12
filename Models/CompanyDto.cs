namespace InvoiceAPI.Models
{
    public class CompanyDto
    {

        public required string Name { get; set; }
        public required int TIN { get; set; }
        public CompanyContactDetailsDto Contact { get; set; }
        public CompanyAddressDetailsDto Address { get; set; }

        public List<ContractorSummaryDto>? Contractors { get; set; }

        //public List<ProductDto> Products { get; set; } #todo
        //public List<InvoiceDto> Invoices { get; set; } #todo



    }
}
