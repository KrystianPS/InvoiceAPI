namespace InvoiceAPI.Models
{
    public class CompanyDto
    {
        public required string Name { get; set; }
        public required int TIN { get; set; }
        public required string EmailAdress { get; set; }

        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string AddresLine1 { get; set; }
        public required string AddresLine2 { get; set; }
        public required string PostalCode { get; set; }


        public List<ContractorDto> Contractors { get; set; }

        //public List<ProductDto> Products { get; set; } #todo
        //public List<InvoiceDto> Invoices { get; set; } #todo



    }
}
