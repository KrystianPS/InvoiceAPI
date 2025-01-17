using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.Models.ContractorModel;

namespace InvoiceAPI.Services
{
    public interface IContractorService
    {
        Task<int> CreateContractor(CreateContractorDto dto);

        bool UpdateContractor(int id, UpdateContractorDto dto);
        Task<bool> DeleteContractor(int id);
        List<ContractorDto> GetAll();
        ContractorDto GetById(int id);
    }
}