using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models
{
    public class CreateContractorDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? TIN { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public CreateContractorAddressDetailsDto? Address { get; set; }
        public CreateContractorContactDetailsDto? Contact { get; set; }

    }
}
