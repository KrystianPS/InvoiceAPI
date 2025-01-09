namespace InvoiceAPI.Entities
{
    public class CompanyContactDetails
    {
        public int Id { get; set; }
        public required string Phone { get; set; }
        public required string EmailAddress { get; set; }

        public Company Company { get; set; }
    }
}
