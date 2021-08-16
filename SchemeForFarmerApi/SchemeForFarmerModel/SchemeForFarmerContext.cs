using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchemeForFarmerApi.SchemeForFarmerModel
{
    public partial class SchemeForFarmerContext : DbContext
    {
        public SchemeForFarmerContext()
        {
        }

        public SchemeForFarmerContext(DbContextOptions<SchemeForFarmerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppliedInsurance> AppliedInsurances { get; set; }
        public virtual DbSet<BidHistory> BidHistories { get; set; }
        public virtual DbSet<BidderDetail> BidderDetails { get; set; }
        public virtual DbSet<CityState> CityStates { get; set; }
        public virtual DbSet<FarmerDetail> FarmerDetails { get; set; }
        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public virtual DbSet<LandDetail> LandDetails { get; set; }
        public virtual DbSet<RequestDetail> RequestDetails { get; set; }
        public virtual DbSet<SoldDetail> SoldDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SchemeForFarmer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppliedInsurance>(entity =>
            {
                entity.HasKey(e => e.PolicyNumber)
                    .HasName("pk_AppliedInsurance");

                entity.ToTable("AppliedInsurance");

                entity.Property(e => e.PolicyNumber).ValueGeneratedNever();

                entity.Property(e => e.AadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AadharCardNumberNavigation)
                    .WithMany(p => p.AppliedInsurances)
                    .HasForeignKey(d => d.AadharCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AadharCardNumber_AI");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AppliedInsurances)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CompanyId_AI");
            });

            modelBuilder.Entity<BidHistory>(entity =>
            {
                entity.HasKey(e => e.BidId)
                    .HasName("pk_BidHistory");

                entity.ToTable("BidHistory");

                entity.Property(e => e.BidDate).HasColumnType("datetime");

                entity.Property(e => e.BidPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BidderAadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.BidderAadharCardNumberNavigation)
                    .WithMany(p => p.BidHistories)
                    .HasForeignKey(d => d.BidderAadharCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aadhar_BH");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.BidHistories)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RequestId_BH");
            });

            modelBuilder.Entity<BidderDetail>(entity =>
            {
                entity.HasKey(e => e.AadharCardNumber)
                    .HasName("pk_BidderDetails");

                entity.Property(e => e.AadharCardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AadharDocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.Property(e => e.Pandocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PANDocument");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.TradersLicenseDocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.BidderDetails)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_City_BD");
            });

            modelBuilder.Entity<CityState>(entity =>
            {
                entity.HasKey(e => e.City)
                    .HasName("pk_CityState");

                entity.ToTable("CityState");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FarmerDetail>(entity =>
            {
                entity.HasKey(e => e.AadharCardNumber)
                    .HasName("pk_FarmerDetails");

                entity.Property(e => e.AadharCardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AadharDocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CertificateDocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ifsc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.Property(e => e.Pandocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PANDocument");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.FarmerDetails)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_City_FD");
            });

            modelBuilder.Entity<InsuranceCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("pk_InsuranceCompany");

                entity.ToTable("InsuranceCompany");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SumInsured).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<LandDetail>(entity =>
            {
                entity.HasKey(e => e.LandId)
                    .HasName("pk_LandDetails");

                entity.Property(e => e.AadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.LandDetails)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_City_LD");
            });

            modelBuilder.Entity<RequestDetail>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("pk_RequestDetails");

                entity.Property(e => e.AadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CropQuantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CropType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CuurentBid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FertilizerType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Msp)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("MSP");

                entity.Property(e => e.SoilPhcertificateDocument)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SoilPHCertificateDocument");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AadharCardNumberNavigation)
                    .WithMany(p => p.RequestDetails)
                    .HasForeignKey(d => d.AadharCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aadhar_FD");
            });

            modelBuilder.Entity<SoldDetail>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("pk_SoldDetails");

                entity.Property(e => e.RequestId).ValueGeneratedNever();

                entity.Property(e => e.AadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DateSold).HasColumnType("datetime");

                entity.Property(e => e.SoldPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AadharCardNumberNavigation)
                    .WithMany(p => p.SoldDetails)
                    .HasForeignKey(d => d.AadharCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aadhar_BD");

                entity.HasOne(d => d.Request)
                    .WithOne(p => p.SoldDetail)
                    .HasForeignKey<SoldDetail>(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RequestId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
