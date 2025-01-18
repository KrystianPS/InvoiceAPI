namespace InvoiceAPI.Models.ContractorModel
{
    public class ContractorSummaryDto
    {
        public string Name { get; set; }
        public int? TIN { get; set; }
        //public string EmailAdress { get; set; }
        //public string Phone { get; set; }
        public int RelatedCompanyId { get; set; }
    }
}
