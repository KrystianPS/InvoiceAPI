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

        public ContractorService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ContractorDto GetById(int id)
        {
            var contractor = _dbContext
               .Contractors
               .Include(r => r.Address)
               .Include(r => r.Contact)
               .FirstOrDefault(c => c.Id == id);

            if (contractor is null) throw new NotFoundException("Contractor not found");

            var result = _mapper.Map<ContractorDto>(contractor);

            return result;
        }

        public List<ContractorDto> GetAll()
        {
            var contractors = _dbContext
                .Contractors
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .ToList();

            if (contractors is null) throw new NotFoundException("Contractor not found");

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
        public void DeleteContractor(int id)
        {
            var contractor = _dbContext
                .Contractors
                .FirstOrDefault(c => c.Id == id);

            if (contractor is null) throw new NotFoundException("Contractor not found");

            _dbContext.Contractors.Remove(contractor);
            _dbContext.SaveChanges();

        }

        public void UpdateContractor(int id, UpdateContractorDto dto)
        {
            var contractor = _dbContext
                .Contractors
                .Include(c => c.Address)
                .Include(c => c.Contact)
                .FirstOrDefault(c => c.Id == id);

            if (contractor is null) throw new NotFoundException("Contractor not found");

            contractor.Name = dto.Name ?? contractor.Name;
            contractor.Address.AddressLine1 = dto.AddressLine1 ?? contractor.Address.AddressLine1;
            contractor.Address.AddressLine2 = dto.AddressLine2 ?? contractor.Address.AddressLine2;
            contractor.Address.PostalCode = dto.PostalCode ?? contractor.Address.PostalCode;
            contractor.Address.City = dto.City ?? contractor.Address.City;
            contractor.Address.Country = dto.Country ?? contractor.Address.Country;
            contractor.Contact.EmailAddress = dto.EmailAddress ?? contractor.Contact.EmailAddress;
            contractor.Contact.Phone = dto.Phone ?? contractor.Contact.Phone;


            _dbContext.SaveChanges();
        }





    }
}
