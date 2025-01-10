using InvoiceAPI.Entities;
using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class VatRateSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public VatRateSeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.VatRates.Any())
                {

                    await _dbContext.VatRates.AddRangeAsync(
                        new VatRate { Rate = 0.23m },
                        new VatRate { Rate = 0.08m },
                        new VatRate { Rate = 0.05m },
                        new VatRate { Rate = 0m }
                    );

                    await _dbContext.SaveChangesAsync();


                }
            }
        }
        private IEnumerable<VatRate> GetVatRates()
        {
            var rates = new List<VatRate>()
            {
                new VatRate()
                {
                    Rate = 0.23m
                },
                new VatRate()
                {
                    Rate = 0.08m
                },
                new VatRate()
                {
                    Rate = 0.05m
                },
                new VatRate()
                {
                    Rate = 0m
                }
            };
            return rates;
        }
    }
}
