using InvoiceAPI.Persistance;
using InvoiceAPI.Seeders.EntitySeeders;

namespace InvoiceAPI.Seeders
{
    public class DatabaseSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        private readonly VatRateSeeder _vatRateSeeder;

        public DatabaseSeeder(
            InvoiceAPIDbContext dbContext,
            VatRateSeeder vatRateSeeder)
        {
            _dbContext = dbContext;
            _vatRateSeeder = vatRateSeeder;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {

                await _vatRateSeeder.Seed();


            }


        }
    }
}
