using InvoiceAPI.Entities;
using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class ContractorSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public ContractorSeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Contractors.Any())
                {

                    var testContractor = new Contractor
                    {
                        Name = "ContractorTest1",
                        TIN = 1111111111,
                        CompanyId = 1,
                        Address = new ContractorAddressDetails()
                        {
                            AddressLine1 = "Street Test1",
                            AddressLine2 = "Building",
                            City = "TestCity1",
                            PostalCode = "33-333",
                            Country = "Poland"

                        },
                        Contact = new ContractorContactDetails()
                        {
                            EmailAddress = "contractorTest@test.com",
                            Phone = "+48333333333"

                        },
                    };


                    await _dbContext.Contractors.AddAsync(testContractor);

                    await _dbContext.SaveChangesAsync();


                }
            }
        }
    }
}
