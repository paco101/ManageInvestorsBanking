﻿// <auto-generated />
using System;
using ManageInvestors.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageInvestors.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250118201658_ReUpdated-Investments-Table")]
    partial class ReUpdatedInvestmentsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManageInvestors.Models.Fund", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FundDescription")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FundName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("ISIN")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("LastPrice")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Funds", (string)null);
                });

            modelBuilder.Entity("ManageInvestors.Models.Investment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FundId")
                        .HasColumnType("int");

                    b.Property<int>("InvestorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("PurchasedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<DateTime?>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserTransaction")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("FundId");

                    b.HasIndex("InvestorId");

                    b.ToTable("Investments", (string)null);
                });

            modelBuilder.Entity("ManageInvestors.Models.Investor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Investors", (string)null);
                });

            modelBuilder.Entity("ManageInvestors.Models.Investment", b =>
                {
                    b.HasOne("ManageInvestors.Models.Fund", "Fund")
                        .WithMany("Investments")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ManageInvestors.Models.Investor", "Investor")
                        .WithMany("Investments")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fund");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("ManageInvestors.Models.Fund", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("ManageInvestors.Models.Investor", b =>
                {
                    b.Navigation("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
