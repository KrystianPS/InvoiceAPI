using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.Models.ContractorModel;

namespace InvoiceAPI.Services
{
    public interface IContractorService
    {
        Task<int> CreateContractor(CreateContractorDto dto);

        void UpdateContractor(int id, UpdateContractorDto dto);
        void DeleteContractor(int id);
        List<ContractorDto> GetAll();
        ContractorDto GetById(int id);
    }
}