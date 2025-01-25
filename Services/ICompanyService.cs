using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Models.CompanyModel;

namespace InvoiceAPI.Services
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(CreateCompanyDto dto);
        Task UpdateCompany(int id, UpdateCompanyDto dto);
        Task DeleteCompany(int id);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
    }
}