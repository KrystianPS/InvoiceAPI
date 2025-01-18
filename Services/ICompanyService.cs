using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Models.CompanyModel;

namespace InvoiceAPI.Services
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(CreateCompanyDto dto);
        Task<bool> UpdateCompany(int id, UpdateCompanyDto dto);
        Task<bool> DeleteCompany(int id);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
    }
}