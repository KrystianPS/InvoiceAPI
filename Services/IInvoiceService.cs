using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Models.InvoiceModel;

namespace InvoiceAPI.Services
{
    public interface IInvoiceService
    {
        Task<bool> UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto);
        Task<int> CreateInvoice(CreateInvoiceDto createInvoiceDto);
        Task<bool> DeleteInvoice(int id);
        List<InvoiceDto> GetAll();
        InvoiceDto GetById(int id);
        List<InvoiceDto> GetAllByCompanyId(int id);
        List<InvoiceDto> GetAllByContractorId(int id);
    }
}