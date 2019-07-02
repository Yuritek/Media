using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Models
{
    public partial class DP_MainContext : DbContext
    {
        public DP_MainContext()
        {
        }

        public DP_MainContext(DbContextOptions<DP_MainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DtBase> DtBase { get; set; }
        public virtual DbSet<DtTech> DtTech { get; set; }
        public virtual DbSet<RefMediaType> RefMediaType { get; set; }
        public virtual DbSet<RefPartners> RefPartners { get; set; }
        public virtual DbSet<StmApiClients> StmApiClients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=DP_Main;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtBase>(entity =>
            {
                entity.HasKey(e => e.ObjectUid);

                entity.ToTable("dt_Base");

                entity.Property(e => e.ObjectUid)
                    .HasColumnName("Object_UID")
                    .HasMaxLength(32)
                    .HasDefaultValueSql("(N'=replace(newid(),''-'','')''')");

                entity.Property(e => e.AutorId).HasColumnName("Autor_ID");

                entity.Property(e => e.CommonId)
                    .HasColumnName("Common_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.DateDelete).HasColumnType("date");

                entity.Property(e => e.DtGeoObjectGeoUid)
                    .HasColumnName("dt_Geo_Object_GeoUID")
                    .HasMaxLength(32);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkRefLicenseId).HasColumnName("FK_ref_License_ID");

                entity.Property(e => e.FkRefMediaNetworkId).HasColumnName("FK_ref_MediaNetwork_ID");

                entity.Property(e => e.FkRefMediaTypeId).HasColumnName("FK_ref_MediaType_ID");

                entity.Property(e => e.FkRefPartnerId).HasColumnName("FK_ref_Partner_ID");

                entity.Property(e => e.FkRefUrFaceId).HasColumnName("FK_ref_UrFace_ID");

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LegacyId)
                    .HasColumnName("Legacy_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.ObjectName).HasMaxLength(150);

                entity.Property(e => e.ObjectUidOper)
                    .HasColumnName("Object_UID_Oper")
                    .HasMaxLength(32);

                entity.Property(e => e.Reference).HasMaxLength(4000);

                entity.Property(e => e.UrlPhoto)
                    .HasColumnName("URL_Photo")
                    .HasMaxLength(2000);

                entity.Property(e => e.UrlPresentation)
                    .HasColumnName("URL_Presentation")
                    .HasMaxLength(2000);

                entity.Property(e => e.UrlSchema)
                    .HasColumnName("URL_Schema")
                    .HasMaxLength(2000);

                entity.HasOne(d => d.FkRefMediaType)
                    .WithMany(p => p.DtBase)
                    .HasForeignKey(d => d.FkRefMediaTypeId)
                    .HasConstraintName("FK_dt_Base_FK_MediaType");
            });

            modelBuilder.Entity<DtTech>(entity =>
            {
                entity.HasKey(e => new { e.DtBaseObjectUid, e.Version });

                entity.ToTable("dt_Tech");

                entity.Property(e => e.DtBaseObjectUid)
                    .HasColumnName("dt_Base_Object_UID")
                    .HasMaxLength(32);

                entity.Property(e => e.AutorId).HasColumnName("Autor_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkRefConstrTypeId).HasColumnName("FK_ref_ConstrType_ID");

                entity.Property(e => e.FkRefExpositionTypeId).HasColumnName("FK_ref_Exposition_Type_ID");

                entity.Property(e => e.FkRefSideId).HasColumnName("FK_ref_Side_ID");

                entity.Property(e => e.FkRefSideTypeId).HasColumnName("FK_ref_SideType_ID");

                entity.Property(e => e.FkRefSizeId).HasColumnName("FK_ref_Size_ID");

                entity.Property(e => e.FkVRefInstallationTypeId).HasColumnName("FK_v_ref_InstallationTypeID");

                entity.Property(e => e.FkVRefPlacementTypeId).HasColumnName("FK_v_ref_PlacementTypeID");

                entity.Property(e => e.Height).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.Image).HasMaxLength(2000);

                entity.Property(e => e.Materials).HasMaxLength(2000);

                entity.Property(e => e.Requirements).HasMaxLength(2000);

                entity.Property(e => e.Width).HasColumnType("numeric(10, 3)");

                entity.HasOne(d => d.DtBaseObjectU)
                    .WithMany(p => p.DtTech)
                    .HasForeignKey(d => d.DtBaseObjectUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dt_Tech_dt_Base");
            });

            modelBuilder.Entity<RefMediaType>(entity =>
            {
                entity.HasKey(e => e.MediaTypeId);

                entity.ToTable("ref_MediaType");

                entity.Property(e => e.MediaTypeId).HasColumnName("MediaType_ID");

                entity.Property(e => e.FkRefMediaGroupId).HasColumnName("FK_ref_MediaGroup_ID");

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.MediaType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RefPartners>(entity =>
            {
                entity.HasKey(e => e.PartnerId);

                entity.ToTable("ref_Partners");

                entity.Property(e => e.PartnerId).HasColumnName("Partner_ID");

                entity.Property(e => e.CategoryClntComment)
                    .HasColumnName("Category_Clnt_Comment")
                    .HasMaxLength(500);

                entity.Property(e => e.CategoryClntId).HasColumnName("Category_Clnt_ID");

                entity.Property(e => e.CategorySuppComment)
                    .HasColumnName("Category_Supp_Comment")
                    .HasMaxLength(500);

                entity.Property(e => e.CategorySuppId).HasColumnName("Category_Supp_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkRefPartnerId).HasColumnName("FK_ref_Partner_ID");

                entity.Property(e => e.Keywords).HasMaxLength(500);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MainEmployerId).HasColumnName("MainEmployer_ID");

                entity.Property(e => e.PartnerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PartnerNameFull)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PpBirthday)
                    .HasColumnName("PP_Birthday")
                    .HasColumnType("date");

                entity.Property(e => e.PpSex)
                    .HasColumnName("PP_Sex")
                    .HasMaxLength(1);

                entity.Property(e => e.StatusId).HasColumnName("Status_ID");

                entity.Property(e => e.Synonyms).HasMaxLength(250);
            });

            modelBuilder.Entity<StmApiClients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("stm_api_Clients");

                entity.Property(e => e.ClientId)
                    .HasColumnName("Client_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasColumnName("API_KEY")
                    .HasMaxLength(250);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpirationDate).HasColumnType("date");
            });
        }
    }
}
