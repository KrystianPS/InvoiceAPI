using AutoMapper;
using AutoMapper.QueryableExtensions;
using InvoiceAPI.DtoModels.InvoiceModel;
using InvoiceAPI.Entities;
using InvoiceAPI.Exceptions;
using InvoiceAPI.Models.InvoiceModel;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InvoiceService(InvoiceAPIDbContext dbContext, IMapper mapper, ILogger logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
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
                .ToList() ?? throw new NotFoundException($"Invoices by contractor Id:{id} not found");

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
                .ProjectTo<InvoiceDto>(_mapper.ConfigurationProvider) ?? throw new NotFoundException($"Invoice with Id:{id}not found");


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
                .ToList() ?? throw new NotFoundException($"No invoices found.");

            var result = _mapper.Map<List<InvoiceDto>>(invoices);

            return result;
        }

        public async Task<int> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {


            var company = await _dbContext.Companies.FindAsync(createInvoiceDto.CompanyId) ?? throw new NotFoundException($"Company with ID {createInvoiceDto.CompanyId} not found.");

            var contractor = await _dbContext.Contractors.FindAsync(createInvoiceDto.ContractorId) ?? throw new NotFoundException($"Contractor with ID {createInvoiceDto.ContractorId} not found.");

            var invoiceItems = createInvoiceDto.InvoiceItems.Select(itemDto =>
            {
                var product = _dbContext.Products.Find(itemDto.ProductId) ?? throw new NotFoundException($"Product with ID {itemDto.ProductId} not found.");

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


        public async Task UpdateInvoice(int id, UpdateInvoiceDto updateInvoiceDto)
        {
            var invoice = _dbContext
               .Invoices
               .Include(c => c.InvoiceItems)
               .FirstOrDefault(c => c.Id == id) ?? throw new NotFoundException("Product not found");


            //if not null update data
            invoice.InvoiceNumber = updateInvoiceDto.InvoiceNumber ?? invoice.InvoiceNumber;
            invoice.DueDate = updateInvoiceDto.DueDate ?? invoice.DueDate;
            invoice.InvoiceNote = updateInvoiceDto.InvoiceNote ?? invoice.InvoiceNote;
            invoice.ContractorId = updateInvoiceDto.ContractorId ?? invoice.ContractorId;
            _logger.LogInformation($"Invoice with Id:{id} basic data updated");

            //add new item and save invoice after each item added
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

                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Invoice with Id:{id} items ({updateInvoiceDto.ItemsToAdd.Count()}) added");
            }

            //delete item by id 
            if (updateInvoiceDto.ItemsToDelete != null && updateInvoiceDto.ItemsToDelete.Any())
            {
                invoice.InvoiceItems.RemoveAll(i => updateInvoiceDto.ItemsToDelete.Contains(i.Id));

                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Invoice with Id:{id} item deteled");
            }

            //sum current total invoice values
            var totalNet = invoice.InvoiceItems.Sum(i => i.ItemPriceNet);
            var totalVat = invoice.InvoiceItems.Sum(i => i.ItemVatAmount);
            var totalGross = totalNet + totalVat;

            //set current values in invoice
            invoice.TotalNet = totalNet;
            invoice.TotalVatAmount = totalVat;
            invoice.TotalGross = totalGross;


            _dbContext.Invoices.Update(invoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = _dbContext
                .Invoices
                .FirstOrDefault(p => p.Id == id) ?? throw new NotFoundException($"Invoice with Id:{id} not found.");

            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync();
        }





        //additional basic invoice number creation method = to be updated later             #TODO
        public string GenerateInvoiceNumber(int? lastInvoiceNumber = null)
        {
            string month = DateTime.Now.ToString("MM");
            int nextInvoiceNumber = (lastInvoiceNumber ?? 0) + 1;
            return $"{month}/FV/{nextInvoiceNumber:D3}";
        }
    }

}
