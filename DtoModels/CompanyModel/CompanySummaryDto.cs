namespace InvoiceAPI.DtoModels.CompanyModel
{
    public class CompanySummaryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TIN { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required string Phone { get; set; }
        public required string EmailAddress { get; set; }
    }
}
