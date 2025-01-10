using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class VatRateConfig : IEntityTypeConfiguration<VatRate>
    {
        public void Configure(EntityTypeBuilder<VatRate> eb)
        {
            eb.Property(vr => vr.Rate).HasColumnType("decimal(5,2)");

        }
    }
}
