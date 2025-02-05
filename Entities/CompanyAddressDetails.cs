﻿namespace InvoiceAPI.Entities
{
    public class CompanyAddressDetails
    {
        public int Id { get; set; }
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }

        public Company Company { get; set; }
    }
}
