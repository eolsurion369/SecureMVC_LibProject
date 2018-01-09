using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NW_Central_Library.Models.LibraryModels
{
    public partial class LibProjectContext : DbContext
    {
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddrType> AddrType { get; set; }
        public virtual DbSet<AdultMember> AdultMember { get; set; }
        public virtual DbSet<AdultMemberAddress> AdultMemberAddress { get; set; }
        public virtual DbSet<CheckOut> CheckOut { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<JuvenileMember> JuvenileMember { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<MediaContent> MediaContent { get; set; }
        public virtual DbSet<MediaCopy> MediaCopy { get; set; }
        public virtual DbSet<MediaFormat> MediaFormat { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<MediaTypeFormat> MediaTypeFormat { get; set; }
        public virtual DbSet<MediaTypeGenre> MediaTypeGenre { get; set; }
        public virtual DbSet<MemberEmail> MemberEmail { get; set; }
        public virtual DbSet<MemberPhone> MemberPhone { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Series> Series { get; set; }

        public LibProjectContext(DbContextOptions<LibProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.LibraryDesc)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.LibraryName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddrLn1)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.AddrLn2)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.AddrTypeId)
                    .IsRequired()
                    .HasColumnName("AddrTypeID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddrType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddrTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_AddressType");
            });

            modelBuilder.Entity<AddrType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdultMember>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MidInit)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdultMemberAddress>(entity =>
            {
                entity.HasKey(e => new { e.AdultId, e.AddressId });

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AdultMemberAddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberAddress_Address");

                entity.HasOne(d => d.Adult)
                    .WithMany(p => p.AdultMemberAddress)
                    .HasForeignKey(d => d.AdultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberAddress_AdultMember");
            });

            modelBuilder.Entity<CheckOut>(entity =>
            {
                entity.HasKey(e => new { e.AdultId, e.MediaCopyId });

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.MediaCopyId).HasColumnName("MediaCopyID");

                entity.Property(e => e.CheckedInDate).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.JuvenileId).HasColumnName("JuvenileID");

                entity.HasOne(d => d.Adult)
                    .WithMany(p => p.CheckOut)
                    .HasForeignKey(d => d.AdultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdultCheckOut_AdultMember");

                entity.HasOne(d => d.MediaCopy)
                    .WithMany(p => p.CheckOut)
                    .HasForeignKey(d => d.MediaCopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdultCheckOut_MediaCopy");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Addr)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.InActiveDate).HasColumnType("date");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JuvenileMember>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AdultId });

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MidInit)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Adult)
                    .WithMany(p => p.JuvenileMember)
                    .HasForeignKey(d => d.AdultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JuvenileMember_AdultMember");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Characteristics)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.CopyRightDate).HasColumnType("date");

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.Summary)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_Media_Publisher");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.SeriesId)
                    .HasConstraintName("FK_Media_SeriesId");
            });

            modelBuilder.Entity<MediaContent>(entity =>
            {
                entity.HasKey(e => e.ContentId);

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.ContentItem)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.MediaContent)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaContent_Media");
            });

            modelBuilder.Entity<MediaCopy>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.MediaFormatId)
                    .IsRequired()
                    .HasColumnName("MediaFormatID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MediaGenreId)
                    .IsRequired()
                    .HasColumnName("MediaGenreID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.MediaTypeId)
                    .IsRequired()
                    .HasColumnName("MediaTypeID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.MediaFormat)
                    .WithMany(p => p.MediaCopy)
                    .HasForeignKey(d => d.MediaFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaCopy_MeidaFormat");

                entity.HasOne(d => d.MediaGenre)
                    .WithMany(p => p.MediaCopy)
                    .HasForeignKey(d => d.MediaGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaCopy_Genre");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.MediaCopy)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaCopy_Media");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.MediaCopy)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MediaCopy_MediaType");
            });

            modelBuilder.Entity<MediaFormat>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Format)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InActiveDate).HasColumnType("date");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediaTypeFormat>(entity =>
            {
                entity.HasKey(e => new { e.MediaTypeId, e.MediaFormatId });

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("MediaTypeID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MediaFormatId)
                    .HasColumnName("MediaFormatID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.MediaFormat)
                    .WithMany(p => p.MediaTypeFormat)
                    .HasForeignKey(d => d.MediaFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeFormat_Genre");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.MediaTypeFormat)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeFormat_Format");
            });

            modelBuilder.Entity<MediaTypeGenre>(entity =>
            {
                entity.HasKey(e => new { e.MediaTypeId, e.GenreId });

                entity.Property(e => e.MediaTypeId)
                    .HasColumnName("MediaTypeID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId)
                    .HasColumnName("GenreID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.MediaTypeGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeGenre_Genre");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.MediaTypeGenre)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeGenre_MediaType");
            });

            modelBuilder.Entity<MemberEmail>(entity =>
            {
                entity.HasKey(e => new { e.AdultId, e.EmailId });

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.EmailId).HasColumnName("EmailID");

                entity.Property(e => e.JuvenileId).HasColumnName("JuvenileID");

                entity.HasOne(d => d.Adult)
                    .WithMany(p => p.MemberEmail)
                    .HasForeignKey(d => d.AdultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberEmail_AdultMember");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.MemberEmail)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberEmail_Email");

                entity.HasOne(d => d.JuvenileMember)
                    .WithMany(p => p.MemberEmail)
                    .HasForeignKey(d => new { d.JuvenileId, d.AdultId })
                    .HasConstraintName("FK_MemberEmail_JuvenileMember");
            });

            modelBuilder.Entity<MemberPhone>(entity =>
            {
                entity.HasKey(e => new { e.AdultId, e.PhoneId });

                entity.Property(e => e.AdultId).HasColumnName("AdultID");

                entity.Property(e => e.PhoneId).HasColumnName("PhoneID");

                entity.Property(e => e.JuvenileId).HasColumnName("JuvenileID");

                entity.Property(e => e.PhoneTypeId)
                    .HasColumnName("PhoneTypeID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Adult)
                    .WithMany(p => p.MemberPhone)
                    .HasForeignKey(d => d.AdultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPhone_AdultMember");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.MemberPhone)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberPhone_Phone");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.MemberPhone)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .HasConstraintName("FK_MemberPhone_PhoneType");

                entity.HasOne(d => d.JuvenileMember)
                    .WithMany(p => p.MemberPhone)
                    .HasForeignKey(d => new { d.JuvenileId, d.AdultId })
                    .HasConstraintName("FK_MemberPhone_JuvenileMember");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InActiveDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InActiveDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });
        }
    }
}
