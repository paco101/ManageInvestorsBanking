using ManageInvestors.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ManageInvestors.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<Investment> Investments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.ToTable("Investors");
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                entity.Property(i => i.Firstname).IsRequired().HasMaxLength(25).HasColumnType("varchar(25)");
                entity.Property(i => i.Lastname).IsRequired().HasMaxLength(25).HasColumnType("varchar(25)");
                entity.Property(i => i.Country).IsRequired().HasMaxLength(25).HasColumnType("varchar(25)");
                entity.Property(i => i.Address).HasMaxLength(250).HasColumnType("varchar(250)");
                entity.Property(i => i.Email).IsRequired();
                entity.Property(i => i.Phone).IsRequired();
                entity.Property(i => i.IsDeleted).HasDefaultValue(false);
                entity.HasMany(i => i.Investments)
                      .WithOne(inv => inv.Investor)
                      .HasForeignKey(inv => inv.InvestorId);
                entity.HasQueryFilter(inv => !inv.IsDeleted);
            });

            modelBuilder.Entity<Fund>(entity =>
            {
                entity.ToTable("Funds");
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();
                entity.Property(f => f.FundName).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
                entity.Property(f => f.FundDescription).HasMaxLength(250).HasColumnType("varchar(250)");
                entity.Property(inv => inv.LastPrice).HasColumnType("decimal(18, 3)");
                entity.Property(f => f.ProviderName).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
                entity.Property(f => f.ISIN).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
                entity.Property(i => i.IsDeleted).HasDefaultValue(false);
                entity.HasMany(f => f.Investments)
                      .WithOne(inv => inv.Fund)
                      .HasForeignKey(inv => inv.FundId);
                entity.HasQueryFilter(inv => !inv.IsDeleted);
            });

            modelBuilder.Entity<Investment>(entity =>
            {
                entity.ToTable("Investments");
                entity.HasKey(inv => inv.Id);
                entity.Property(inv => inv.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();
                entity.Property(i => i.IsDeleted).HasDefaultValue(false);
                entity.Property(inv => inv.Quantity)
                      .HasColumnType("decimal(18, 3)");
                entity.Property(f => f.UserTransaction)
                      .HasMaxLength(25)
                      .HasColumnType("varchar(25)");

                // Define relationships using foreign keys
                entity.HasOne(inv => inv.Fund)
                      .WithMany(f => f.Investments)
                      .HasForeignKey(inv => inv.FundId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(inv => inv.Investor)
                      .WithMany(i => i.Investments)
                      .HasForeignKey(inv => inv.InvestorId)
                      .OnDelete(DeleteBehavior.Restrict);


                entity.HasQueryFilter(inv => !inv.IsDeleted);
            });
        }
    }
}
