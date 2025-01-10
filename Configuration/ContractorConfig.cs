using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class ContractorConfig : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> eb)
        {
            eb.HasOne(cad => cad.AddressDetails)
                .WithOne(c => c.Contractor)
                .HasForeignKey<ContractorAddressDetails>(ad => ad.Id);

            eb.HasOne(ccd => ccd.ContactDetails)
                .WithOne(c => c.Contractor)
                .HasForeignKey<ContractorContactDetails>(cd => cd.Id);

            eb.Property(c => c.Name).HasColumnType("varchar(200)");
            eb.Property(c => c.TIN).HasColumnType("varchar(10)");


        }
    }
}
