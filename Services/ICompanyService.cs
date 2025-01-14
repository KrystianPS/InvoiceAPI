using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(CreateCompanyDto dto);

        Task<bool> DeleteCompany(int id);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
    }
}