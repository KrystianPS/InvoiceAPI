using AutoMapper;
using InvoiceAPI.DtoModels.CompanyModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Exceptions;
using InvoiceAPI.Models.CompanyModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyService> _logger;


        public CompanyService(InvoiceAPIDbContext dbContext, IMapper mapper, ILogger<CompanyService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<CompanyDto> GetAll()
        {
            _logger.LogInformation("Get all companies query invoked");
            var companies = _dbContext
                .Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .ToList() ?? throw new NotFoundException("Company not found");

            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies);
            return companiesDtos;
        }

        public CompanyDto GetById(int id)
        {
            _logger.LogInformation($"Get comapny by Id:{id} query invoked");
            var company = _dbContext.Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .Include(c => c.Contractors)
                .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException($"Company with Id:{id} not found");

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }


        public async Task<int> CreateCompany(CreateCompanyDto dto)
        {
            _logger.LogInformation("Create company query invoked");
            var company = _mapper.Map<Company>(dto);

            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company.Id;
        }

        public async Task DeleteCompany(int id)
        {
            _logger.LogInformation($"Delete company with id:{id} invoked");
            var company = _dbContext
                .Companies
                .FirstOrDefault(p => p.Id == id) ?? throw new NotFoundException($"Company with Id:{id} not found");


            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCompany(int id, UpdateCompanyDto dto)
        {
            _logger.LogInformation($"Update company Id:{id} query invoked");
            var company = _dbContext
                .Companies
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException($"Company with Id:{id}not found");


            company.Name = dto.Name ?? company.Name;

            company.Address.AddressLine1 = dto.AddressLine1 ?? company.Address.AddressLine1;
            company.Address.AddressLine2 = dto.AddressLine2 ?? company.Address.AddressLine2;
            company.Address.PostalCode = dto.PostalCode ?? company.Address.PostalCode;
            company.Address.City = dto.City ?? company.Address.City;

            company.Contact.EmailAddress = dto.EmailAddress ?? company.Contact.EmailAddress;
            company.Contact.Phone = dto.Phone ?? company.Contact.Phone;


            await _dbContext.SaveChangesAsync();
        }
    }
}
