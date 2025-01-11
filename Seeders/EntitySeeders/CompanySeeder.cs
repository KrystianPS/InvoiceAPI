using InvoiceAPI.Entities;
using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class CompanySeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public CompanySeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Companies.Any())
                {


                    var newCompany = new Company
                    {
                        Name = "TestCompany",
                        TIN = 111111111,
                        AddressDetails = new CompanyAddressDetails
                        {
                            AddressLine1 = "AddressLine1",
                            PostalCode = "11-111",
                            City = "Gdańsk",
                            Country = "Polska"
                        },
                        ContactDetails = new CompanyContactDetails
                        {
                            EmailAddress = "testCompany@test.com",
                            Phone = "+48222222222"
                        }
                    };
                    await _dbContext.Companies.AddAsync(newCompany);
                    await _dbContext.SaveChangesAsync();


                }
            }
        }
    }
}
