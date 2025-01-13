namespace InvoiceAPI.Models
{
    public class CreateContractorDto
    {

        public string Name { get; set; }
        public int? TIN { get; set; }
        public int CompanyId { get; set; }
        public CreateContractorAddressDetailsDto? Address { get; set; }
        public CreateContractorContactDetailsDto? Contact { get; set; }

    }
}
