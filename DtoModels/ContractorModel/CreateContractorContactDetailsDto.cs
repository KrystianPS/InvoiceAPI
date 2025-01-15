using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.ContractorModel
{
    public class CreateContractorContactDetailsDto
    {
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
