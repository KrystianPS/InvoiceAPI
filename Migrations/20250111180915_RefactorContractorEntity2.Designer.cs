﻿// <auto-generated />
using System;
using InvoiceAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvoiceAPI.Migrations
{
    [DbContext(typeof(InvoiceAPIDbContext))]
    [Migration("20250111180915_RefactorContractorEntity2")]
    partial class RefactorContractorEntity2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvoiceAPI.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TIN")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.CompanyAddressDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompaniesAddressDetails");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.CompanyContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompaniesContactDetails");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TIN")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Contractors_Name");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ContractorAddressDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContractorsAddressDetails");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ContractorContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContractorsContactDetails");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ContractorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNote")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalGross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalNet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalVatAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ContractorId");

                    b.HasIndex("InvoiceNumber")
                        .HasDatabaseName("IX_Invoices_InvoiceNumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.InvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPriceGross")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ItemPriceNet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ItemVatAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("VatRate")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPriceNet")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Products_Name");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.VatRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("VatRates");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.CompanyAddressDetails", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Company", "Company")
                        .WithOne("Address")
                        .HasForeignKey("InvoiceAPI.Entities.CompanyAddressDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.CompanyContactDetails", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Company", "Company")
                        .WithOne("Contact")
                        .HasForeignKey("InvoiceAPI.Entities.CompanyContactDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Contractor", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Company", "Company")
                        .WithMany("Contractors")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ContractorAddressDetails", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Contractor", "Contractor")
                        .WithOne("Address")
                        .HasForeignKey("InvoiceAPI.Entities.ContractorAddressDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ContractorContactDetails", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Contractor", "Contractor")
                        .WithOne("Contact")
                        .HasForeignKey("InvoiceAPI.Entities.ContractorContactDetails", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Invoice", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Company", "Company")
                        .WithMany("Invoices")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceAPI.Entities.Contractor", "Contractor")
                        .WithMany("Invoices")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.InvoiceItem", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceAPI.Entities.Product", "Product")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Product", b =>
                {
                    b.HasOne("InvoiceAPI.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceAPI.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Company", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Contractors");

                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Contractor", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Contact");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.Product", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("InvoiceAPI.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}