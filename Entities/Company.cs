namespace InvoiceAPI.Entities
{
    public class Company

    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required int TIN { get; set; }
        public required CompanyAddressDetails AddressDetails { get; set; }
        public required CompanyContactDetails ContactDetails { get; set; }



    }
}
