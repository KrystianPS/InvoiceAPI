using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class InvoiceItemConfig : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> eb)
        {

            eb.Property(ii => ii.VatRate).HasColumnType("decimal(5,2");
            eb.Property(ii => ii.ItemPriceGross).HasColumnType("decimal(18,2");
            eb.Property(ii => ii.ItemPriceNet).HasColumnType("decimal(18,2");
            eb.Property(ii => ii.ItemVatAmount).HasColumnType("decimal(18,2");


            eb.HasOne(ii => ii.Product)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(ii => ii.ProductId)
                .OnDelete(DeleteBehavior.SetNull);



        }
    }
}
