using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.CompanyModel
{
    public class CreateCompanyAddressDetailsDto
    {
        [Required]
        [MaxLength(75)]
        public string AddressLine1 { get; set; }
        [MaxLength(75)]
        public string? AddressLine2 { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]

        public string Country { get; set; }
    }
}
