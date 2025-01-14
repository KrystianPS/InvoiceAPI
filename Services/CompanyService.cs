using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;


        public CompanyService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CompanyDto> GetAll()
        {
            var companies = _dbContext
                .Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .ToList();

            if (companies is null)
            {
                return null;
            }

            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies);
            return companiesDtos;
        }

        public CompanyDto GetById(int id)
        {
            var company = _dbContext.Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .FirstOrDefault(c => c.Id == id);
            if (company is null)
            {
                return null;
            }


            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }


        public async Task<int> CreateCompany(CreateCompanyDto dto)
        {
            var company = _mapper.Map<Company>(dto);

            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company.Id;
        }

        public async Task<bool> DeleteCompany(int id)
        {

            var company = _dbContext
                .Companies
                .FirstOrDefault(p => p.Id == id);

            if (company is null) return false;

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
