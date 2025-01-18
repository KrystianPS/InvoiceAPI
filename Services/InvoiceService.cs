using AutoMapper;
using AutoMapper.QueryableExtensions;
using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Models.InvoiceModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceService(InvoiceAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<InvoiceDto> GetAllByCompanyId(int id)
        {
            var invoices = _dbContext
             .Invoices
             .Include(r => r.Contractor)
             .Include(r => r.Company)
             .Include(r => r.InvoiceItems)
             .Where(c => c.CompanyId == id)
             .ToList();

            var result = _mapper.Map<List<InvoiceDto>>(invoices);
            return result;

        }
        public List<InvoiceDto> GetAllByContractorId(int id)
        {
            var invoices = _dbContext
                .Invoices
                .Include(c => c.Contractor)
                .Include(c => c.Contractor.Address)
                .Include(c => c.Contractor.Contact)
                .Include(c => c.Company)
                .Include(c => c.Company.Address)
                .Include(c => c.Company.Contact)
                .Include(r => r.InvoiceItems)
                .Where(c => c.ContractorId == id)
                .ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider)
                .ToList();

            return invoices;
        }

        public InvoiceDto GetById(int id)
        {
            var invoice = _dbContext
                .Invoices
                .Include(c => c.Contractor)
                .Include(c => c.Contractor.Address)
                .Include(c => c.Contractor.Contact)
                .Include(c => c.Company)
                .Include(c => c.Company.Address)
                .Include(c => c.Company.Contact)
                .Include(r => r.InvoiceItems)
                .Where(c => c.Id == id)
                .ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();


            var result = _mapper.Map<InvoiceDto>(invoice);

            return result;
        }

        public List<InvoiceDto> GetAll()
        {
            var invoices = _dbContext
                .Invoices
                .Include(c => c.Contractor)
                .Include(c => c.Contractor.Address)
                .Include(c => c.Contractor.Contact)
                .Include(c => c.Company)
                .Include(c => c.Company.Address)
                .Include(c => c.Company.Contact)
                .Include(c => c.InvoiceItems)
                .ToList();



            if (invoices is null)
            {
                return null;
            }

            var result = _mapper.Map<List<InvoiceDto>>(invoices);

            return result;
        }
        public async Task<bool> DeleteInvoice(int id)
        {
            var invoice = _dbContext
                .Invoices
                .FirstOrDefault(p => p.Id == id);

            if (invoice is null) return false;

            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<int> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {


            var company = await _dbContext.Companies.FindAsync(createInvoiceDto.CompanyId);
            if (company == null)
            {
                throw new ArgumentException($"Company with ID {createInvoiceDto.CompanyId} not found.");
            }


            var contractor = await _dbContext.Contractors.FindAsync(createInvoiceDto.ContractorId);
            if (contractor == null)
            {
                throw new ArgumentException($"Contractor with ID {createInvoiceDto.ContractorId} not found.");
            }


            var invoiceItems = createInvoiceDto.InvoiceItems.Select(itemDto =>
            {
                var product = _dbContext.Products.Find(itemDto.ProductId);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {itemDto.ProductId} not found.");
                }

                var itemPriceNet = product.UnitPriceNet * itemDto.Quantity;
                var itemVatAmount = itemPriceNet * itemDto.VatRate / 100;
                var itemPriceGross = itemPriceNet + itemVatAmount;


                return new InvoiceItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    ItemPriceNet = itemPriceNet,
                    VatRate = itemDto.VatRate,
                    ItemVatAmount = itemVatAmount,
                    ItemPriceGross = itemPriceGross
                };
            }).ToList();


            var totalNet = invoiceItems.Sum(i => i.ItemPriceNet);
            var totalVat = invoiceItems.Sum(i => i.ItemVatAmount);
            var totalGross = totalNet + totalVat;


            var invoice = new Invoice
            {
                InvoiceNumber = createInvoiceDto.InvoiceNumber ?? GenerateInvoiceNumber(),
                IssueDate = DateTime.UtcNow,
                DueDate = createInvoiceDto.DueDate,
                InvoiceNote = createInvoiceDto.InvoiceNote,
                CompanyId = createInvoiceDto.CompanyId,
                ContractorId = createInvoiceDto.ContractorId,
                TotalNet = totalNet,
                TotalVatAmount = totalVat,
                TotalGross = totalGross,
                InvoiceItems = invoiceItems
            };


            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();

            return invoice.Id;
        }


        public async Task<bool> UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto)
        {
            var invoice = _dbContext
               .Invoices
               .Include(c => c.InvoiceItems)
               .FirstOrDefault(c => c.Id == id);

            if (invoice is null)
            {
                return false;
            }



            //if not null update data
            invoice.InvoiceNumber = updateInvoiceDto.InvoiceNumber ?? invoice.InvoiceNumber;
            invoice.DueDate = updateInvoiceDto.DueDate ?? invoice.DueDate;
            invoice.InvoiceNote = updateInvoiceDto.InvoiceNote ?? invoice.InvoiceNote;
            invoice.ContractorId = updateInvoiceDto.ContractorId ?? invoice.ContractorId;



            //add
            if (updateInvoiceDto.ItemsToAdd != null && updateInvoiceDto.ItemsToAdd.Any())
            {
                foreach (var itemToAdd in updateInvoiceDto.ItemsToAdd)
                {
                    var product = await _dbContext.Products.FindAsync(itemToAdd.ProductId);
                    if (product == null)
                    {
                        throw new ArgumentException($"Product with ID {itemToAdd.ProductId} not found.");
                    }

                    var itemPriceNet = product.UnitPriceNet * itemToAdd.Quantity;
                    var itemVatAmount = itemPriceNet * itemToAdd.VatRate / 100;
                    var itemPriceGross = itemPriceNet + itemVatAmount;

                    var newItem = new InvoiceItem
                    {
                        ProductId = itemToAdd.ProductId,
                        Quantity = itemToAdd.Quantity,
                        VatRate = itemToAdd.VatRate,
                        ItemPriceNet = itemPriceNet,
                        ItemVatAmount = itemVatAmount,
                        ItemPriceGross = itemPriceGross
                    };

                    invoice.InvoiceItems.Add(newItem);
                }

                // Zapisanie zmian po dodaniu nowych pozycji
                await _dbContext.SaveChangesAsync();
            }

            //delete item by id 
            if (updateInvoiceDto.ItemsToDelete != null && updateInvoiceDto.ItemsToDelete.Any())
            {
                invoice.InvoiceItems.RemoveAll(i => updateInvoiceDto.ItemsToDelete.Contains(i.Id));

                await _dbContext.SaveChangesAsync();
            }



            var totalNet = invoice.InvoiceItems.Sum(i => i.ItemPriceNet);
            var totalVat = invoice.InvoiceItems.Sum(i => i.ItemVatAmount);
            var totalGross = totalNet + totalVat;

            // Przypisanie obliczonych wartości do faktury
            invoice.TotalNet = totalNet;
            invoice.TotalVatAmount = totalVat;
            invoice.TotalGross = totalGross;



            _dbContext.Invoices.Update(invoice);
            await _dbContext.SaveChangesAsync();

            return true;

        }





        //additional basic invoice number creation method = to be developed later #todo
        public string GenerateInvoiceNumber(int? lastInvoiceNumber = null)
        {
            string month = DateTime.Now.ToString("MM");
            int nextInvoiceNumber = (lastInvoiceNumber ?? 0) + 1;
            return $"{month}/FV/{nextInvoiceNumber:D3}";
        }
    }

}
