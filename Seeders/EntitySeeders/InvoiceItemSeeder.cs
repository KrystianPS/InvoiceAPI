using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class InvoiceItemSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public InvoiceItemSeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.InvoiceItems.Any())
                {



                    await _dbContext.SaveChangesAsync();


                }
            }
        }
    }
}
