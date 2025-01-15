using InvoiceAPI.Models.ContractorModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.CompanyModel
{
    public class CreateCompanyDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int TIN { get; set; }
        [Required]
        public CreateContractorAddressDetailsDto Address { get; set; }
        [Required]
        public CreateContractorContactDetailsDto Contact { get; set; }

    }
}
