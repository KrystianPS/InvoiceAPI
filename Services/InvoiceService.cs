using AutoMapper;
using InvoiceAPI.Entities;
using InvoiceAPI.Models.InvoiceModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class InvoiceService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateIncvoice(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);

            await _dbContext.Invoices.AddAsync(invoice);
            await _dbContext.SaveChangesAsync();

            return invoice.Id;
        }
        public async Task<bool> DeleteIncvoice(int id)
        {
            var invoice = _dbContext
                .Invoices
                .FirstOrDefault(p => p.Id == id);

            if (invoice is null) return false;

            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public InvoiceDto GetById(int id)
        {
            var invoice = _dbContext
               .Invoices
               .Include(r => r.Address)
               .Include(r => r.Contact)
               .FirstOrDefault(c => c.Id == id);

            if (invoice is null)
            {
                return null;
            }

            var result = _mapper.Map<InvoiceDto>(invoice);

            return result;
        }

        public List<InvoiceDto> GetAll()
        {
            var invoices = _dbContext
                .Invoices
                .Include(c => c.Contractor)
                .Include(c => c.Company)
                .Include(c => c.InvoiceItems)
                .ToList();

            if (invoices is null)
            {
                return null;
            }

            var result = _mapper.Map<List<IncvoiceDto>>(invoices);

            return result;
        }

    }
}
