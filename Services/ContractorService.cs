using AutoMapper;
using InvoiceAPI.Entities;
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

            if (contractor is null)
            {
                return null;
            }

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

            if (contractors is null)
            {
                return null;
            }

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
        public async Task<bool> DeleteContractor(int id)
        {
            var contractor = _dbContext
                .Contractors
                .FirstOrDefault(p => p.Id == id);

            if (contractor is null) return false;

            _dbContext.Contractors.Remove(contractor);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
