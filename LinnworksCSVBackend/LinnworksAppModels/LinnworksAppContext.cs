using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class LinnworksAppContext : DbContext
    {
        public LinnworksAppContext()
        {
        }

        public LinnworksAppContext(DbContextOptions<LinnworksAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogActionType> LogActionTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesChannel> SalesChannels { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=LinnworksApp;User ID=DESKTOP-74ON82Q\\gunay; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Countries_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Countries_Users");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.ItemTypes)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_ItemTypes_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ItemTypes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ItemTypes_Users");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK_Logs_LogActionTypes");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Logs_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Logs_Users");
            });

            modelBuilder.Entity<LogActionType>(entity =>
            {
                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.LogActionTypes)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_LogActionTypes_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LogActionTypes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LogActionTypes_Users");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Regions_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Regions_Users");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.OrderPriority)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Countrie)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CountrieId)
                    .HasConstraintName("FK_Sales_Countries");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK_Sales_ItemTypes");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_Sales_Regions");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Sales_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Sales_SalesChannel");
            });

            modelBuilder.Entity<SalesChannel>(entity =>
            {
                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.SalesChannels)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_SalesChannel_Transaction");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SalesChannels)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SalesChannel_Users");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transaction_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Users_Transaction");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
