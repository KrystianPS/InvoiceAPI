using InvoiceAPI.Persistance;

namespace InvoiceAPI.Seeders.EntitySeeders
{
    public class ProductSeeder
    {
        private readonly InvoiceAPIDbContext _dbContext;
        public ProductSeeder(InvoiceAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {



                    await _dbContext.SaveChangesAsync();


                }
            }
        }
    }
}
