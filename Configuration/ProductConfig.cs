using InvoiceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceAPI.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> eb)
        {
            eb.HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            eb.Property(p => p.UnitPriceNet).HasColumnType("decimal(18,2)");
            eb.Property(p => p.Name).HasColumnType("varchar(30)");
            eb.Property(p => p.Description).HasColumnType("varchar(200)");
        }
    }
}

