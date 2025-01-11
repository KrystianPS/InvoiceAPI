using InvoiceAPI.Persistance;
using InvoiceAPI.Seeders.EntitySeeders;

namespace InvoiceAPI.Seeders
{
    public class DatabaseSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly VatRateSeeder _vatRateSeeder;
        private readonly ContractorSeeder _contractorSeeder;
        private readonly CompanySeeder _companySeeder;

        public DatabaseSeeder(
            InvoiceAPIDbContext dbContext,
            VatRateSeeder vatRateSeeder,
            ContractorSeeder contractorSeeder,
            CompanySeeder companySeeder)
        {
            _dbContext = dbContext;
            _vatRateSeeder = vatRateSeeder;
            _contractorSeeder = contractorSeeder;
            _companySeeder = companySeeder;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {

                await _vatRateSeeder.Seed();
                await _companySeeder.Seed();
                await _contractorSeeder.Seed();


            }


        }
    }
}
