using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class ContractorConfig : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> eb)
        {
            eb.HasOne(cad => cad.Address)
                .WithOne(c => c.Contractor)
                .HasForeignKey<ContractorAddressDetails>(ad => ad.Id);

            eb.HasOne(ccd => ccd.Contact)
                .WithOne(c => c.Contractor)
                .HasForeignKey<ContractorContactDetails>(cd => cd.Id);

            eb.HasOne(con => con.Company)
                .WithMany(c => c.Contractors)
                .HasForeignKey(con => con.CompanyId);

            eb.Property(c => c.Name).HasColumnType("varchar(200)");
            eb.HasIndex(c => c.Name).HasDatabaseName("IX_Contractors_Name");

            eb.Property(c => c.TIN).HasColumnType("varchar(10)");



        }
    }
}
