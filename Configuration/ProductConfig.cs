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

            eb.HasOne(p => p.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);



            eb.Property(p => p.Name).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            eb.HasIndex(p => p.Name).HasDatabaseName("IX_Products_Name");

            eb.Property(p => p.UnitPriceNet).IsRequired().HasColumnType("decimal(18,2)");

            eb.Property(p => p.Description).HasMaxLength(200).HasColumnType("varchar(200)");
        }
    }
}

