using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface IContractorService
    {
        Task<int> CreateContractor(CreateContractorDto dto);

        Task<bool> DeleteContractor(int id);
        List<ContractorDto> GetAll();
        ContractorDto GetById(int id);
    }
}