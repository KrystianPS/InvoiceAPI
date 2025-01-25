using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Models.InvoiceModel;

namespace InvoiceAPI.Services
{
    public interface IInvoiceService
    {
        Task<int> CreateInvoice(CreateInvoiceDto createInvoiceDto);
        Task UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto);
        Task DeleteInvoice(int id);
        List<InvoiceDto> GetAll();
        InvoiceDto GetById(int id);
        List<InvoiceDto> GetAllByCompanyId(int id);
        List<InvoiceDto> GetAllByContractorId(int id);
    }
}