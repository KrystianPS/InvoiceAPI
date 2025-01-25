using AutoMapper;
using InvoiceAPI.DtoModels.ContractorModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Exceptions;
using InvoiceAPI.Models.ContractorModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class ContractorService : IContractorService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ContractorService> _logger;

        public ContractorService(InvoiceAPIDbContext dbContext, IMapper mapper, ILogger<ContractorService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public ContractorDto GetById(int id)
        {
            var contractor = _dbContext
               .Contractors
               .Include(r => r.Address)
               .Include(r => r.Contact)
               .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException($"Contractor with Id:{id}not found");

            var result = _mapper.Map<ContractorDto>(contractor);

            return result;
        }

        public List<ContractorDto> GetAll()
        {
            var contractors = _dbContext
                .Contractors
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .ToList() ?? throw new NotFoundException("No contractors found");

            var result = _mapper.Map<List<ContractorDto>>(contractors);

            return result;
        }

        public async Task<int> CreateContractor(CreateContractorDto dto)
        {
            var contractor = _mapper.Map<Contractor>(dto);

            await _dbContext.Contractors.AddAsync(contractor);
            await _dbContext.SaveChangesAsync();

            return contractor.Id;
        }
        public async Task DeleteContractor(int id)
        {
            var contractor = _dbContext
                .Contractors
                .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException($"Contractor with Id:{id} not found");

            _dbContext.Contractors.Remove(contractor);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateContractor(int id, UpdateContractorDto dto)
        {
            var contractor = _dbContext
                .Contractors
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException($"Contractor with Id:{id} not found");


            contractor.Name = dto.Name ?? contractor.Name;
            contractor.Address.AddressLine1 = dto.AddressLine1 ?? contractor.Address.AddressLine1;
            contractor.Address.AddressLine2 = dto.AddressLine2 ?? contractor.Address.AddressLine2;
            contractor.Address.PostalCode = dto.PostalCode ?? contractor.Address.PostalCode;
            contractor.Address.City = dto.City ?? contractor.Address.City;
            contractor.Address.Country = dto.Country ?? contractor.Address.Country;
            contractor.Contact.EmailAddress = dto.EmailAddress ?? contractor.Contact.EmailAddress;
            contractor.Contact.Phone = dto.Phone ?? contractor.Contact.Phone;
            _logger.LogInformation($"Contractor with Id:{id} updated");

            await _dbContext.SaveChangesAsync();
        }





    }
}
