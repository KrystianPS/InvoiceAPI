using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(CreateCompanyDto dto);
        List<CompanyDto> GetAll();
        CompanyDto GetById(int id);
    }
}