using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.DtoModels.InvoiceModel;

namespace InvoiceAPI.Models.InvoiceModel
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public required string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalVatAmount { get; set; }
        public decimal TotalGross { get; set; }
        public string InvoiceNote { get; set; }

        public int InvoiceItemsCount => InvoiceItems.Count;

        public CompanyForInvoiceDto Company { get; set; }
        public ContractorForInvoiceDto Contractor { get; set; }
        public List<InvoiceItemDto> InvoiceItems { get; set; }

    }
}
