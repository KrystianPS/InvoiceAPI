namespace InvoiceAPI.DtoModels.ContractorModel
{
    public class UpdateContractorDto
    {
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
