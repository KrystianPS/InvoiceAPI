using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Models.CompanyModel;

namespace InvoiceAPI.Services
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(CreateCompanyDto dto);
        void UpdateCompany(int id, UpdateCompanyDto dto);
        void DeleteCompany(int id);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
    }
}