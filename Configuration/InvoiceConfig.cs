using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> eb)
        {
            eb.HasOne(i => i.Company)
              .WithMany(c => c.Invoices)
              .HasForeignKey(i => i.CompanyId)
              .OnDelete(DeleteBehavior.Cascade);


            eb.HasOne(i => i.Contractor)
              .WithMany(c => c.Invoices)
              .HasForeignKey(i => i.ContractorId)
              .OnDelete(DeleteBehavior.NoAction);

            eb.HasMany(i => i.InvoiceItems)
               .WithOne(ii => ii.Invoice)
               .HasForeignKey(ii => ii.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);

            eb.Property(i => i.TotalGross).HasColumnType("decimal(18,2)");
            eb.Property(i => i.TotalNet).HasColumnType("decimal(18,2)");
            eb.Property(i => i.TotalVatAmount).HasColumnType("decimal(18,2)");
            eb.Property(i => i.InvoiceNote).HasColumnType("varchar(200)");


            eb.HasIndex(i => i.InvoiceNumber).HasDatabaseName("IX_Invoices_InvoiceNumber");


        }


    }

}

