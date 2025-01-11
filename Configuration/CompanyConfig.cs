using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> eb)
        {
            eb.HasOne(cad => cad.Address)
                .WithOne(c => c.Company)
                .HasForeignKey<CompanyAddressDetails>(ad => ad.Id)
                .OnDelete(DeleteBehavior.Cascade);

            eb.HasOne(ccd => ccd.Contact)
                .WithOne(c => c.Company)
                .HasForeignKey<CompanyContactDetails>(cd => cd.Id)
                .OnDelete(DeleteBehavior.Cascade);




        }
    }
}
