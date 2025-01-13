using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface IContractorService
    {
        int CreateContractor(CreateContractorDto dto);
        List<ContractorDto> GetAll();
        ContractorDto GetById(int id);
    }
}