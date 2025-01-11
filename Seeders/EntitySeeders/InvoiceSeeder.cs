using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class InvoiceSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public InvoiceSeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Invoices.Any())
                {



                    await _dbContext.SaveChangesAsync();


                }
            }
        }
    }
}
