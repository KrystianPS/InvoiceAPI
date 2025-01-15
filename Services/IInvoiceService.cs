using InvoiceAPI.Models.InvoiceModel;

namespace InvoiceAPI.Services
{
    public interface IInvoiceService
    {
        Task<int> CreateInvoice(CreateInvoiceDto createInvoiceDto);
        Task<bool> DeleteIncvoice(int id);
        List<InvoiceDto> GetAll();
        List<InvoiceDto> GetAllByCompanyId(int id);
        List<InvoiceDto> GetAllByContractorId(int id);
        InvoiceDto GetById(int id);
    }
}