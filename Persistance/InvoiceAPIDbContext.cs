using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Persistance
{
    public class InvoiceAPIDbContext : DbContext
    {

        public InvoiceAPIDbContext(DbContextOptions<InvoiceAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAddressDetails> CompaniesAddressDetails { get; set; }
        public DbSet<CompanyContactDetails> CompaniesContactDetails { get; set; }

        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContractorAddressDetails> ContractorsAddressDetails { get; set; }
        public DbSet<ContractorContactDetails> ContractorsContactDetails { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<VatRate> VatRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
