﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication4.Data;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(LibProjectContext))]
    [Migration("20180108232550_init_libProject")]
    partial class init_libProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LibraryDesc")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("LibraryName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("AddrLn1")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<string>("AddrLn2")
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<string>("AddrTypeId")
                        .IsRequired()
                        .HasColumnName("AddrTypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AddrTypeId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.AddrType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("AddrType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.AdultMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("MidInit")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Suffix")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("AdultMember");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.AdultMemberAddress", b =>
                {
                    b.Property<int>("AdultId")
                        .HasColumnName("AdultID");

                    b.Property<int>("AddressId")
                        .HasColumnName("AddressID");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.HasKey("AdultId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("AdultMemberAddress");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.CheckOut", b =>
                {
                    b.Property<int>("AdultId")
                        .HasColumnName("AdultID");

                    b.Property<int>("MediaCopyId")
                        .HasColumnName("MediaCopyID");

                    b.Property<DateTime?>("CheckedInDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<int?>("JuvenileId")
                        .HasColumnName("JuvenileID");

                    b.HasKey("AdultId", "MediaCopyId");

                    b.HasIndex("MediaCopyId");

                    b.ToTable("CheckOut");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Addr")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.JuvenileMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("AdultId")
                        .HasColumnName("AdultID");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("MidInit")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Suffix")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("Id", "AdultId");

                    b.HasIndex("AdultId");

                    b.ToTable("JuvenileMember");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<string>("Characteristics")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.Property<DateTime>("CopyRightDate")
                        .HasColumnType("date");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<int?>("PublisherId")
                        .HasColumnName("PublisherID");

                    b.Property<int?>("SeriesId");

                    b.Property<string>("Summary")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaContent", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContentID");

                    b.Property<string>("ContentItem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("ContentItemOrder");

                    b.Property<int>("MediaId")
                        .HasColumnName("MediaID");

                    b.HasKey("ContentId");

                    b.HasIndex("MediaId");

                    b.ToTable("MediaContent");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("CopyNumber");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("MediaFormatId")
                        .IsRequired()
                        .HasColumnName("MediaFormatID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("MediaGenreId")
                        .IsRequired()
                        .HasColumnName("MediaGenreID")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.Property<int>("MediaId")
                        .HasColumnName("MediaID");

                    b.Property<string>("MediaTypeId")
                        .IsRequired()
                        .HasColumnName("MediaTypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("MediaFormatId");

                    b.HasIndex("MediaGenreId");

                    b.HasIndex("MediaId");

                    b.HasIndex("MediaTypeId");

                    b.ToTable("MediaCopy");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaFormat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Format")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("MediaFormat");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("MediaType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaTypeFormat", b =>
                {
                    b.Property<string>("MediaTypeId")
                        .HasColumnName("MediaTypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("MediaFormatId")
                        .HasColumnName("MediaFormatID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("MediaTypeId", "MediaFormatId");

                    b.HasIndex("MediaFormatId");

                    b.ToTable("MediaTypeFormat");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaTypeGenre", b =>
                {
                    b.Property<string>("MediaTypeId")
                        .HasColumnName("MediaTypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("GenreId")
                        .HasColumnName("GenreID")
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("MediaTypeId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MediaTypeGenre");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MemberEmail", b =>
                {
                    b.Property<int>("AdultId")
                        .HasColumnName("AdultID");

                    b.Property<int>("EmailId")
                        .HasColumnName("EmailID");

                    b.Property<int?>("JuvenileId")
                        .HasColumnName("JuvenileID");

                    b.HasKey("AdultId", "EmailId");

                    b.HasIndex("EmailId");

                    b.HasIndex("JuvenileId", "AdultId");

                    b.ToTable("MemberEmail");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MemberPhone", b =>
                {
                    b.Property<int>("AdultId")
                        .HasColumnName("AdultID");

                    b.Property<int>("PhoneId")
                        .HasColumnName("PhoneID");

                    b.Property<int?>("JuvenileId")
                        .HasColumnName("JuvenileID");

                    b.Property<string>("PhoneTypeId")
                        .HasColumnName("PhoneTypeID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("AdultId", "PhoneId");

                    b.HasIndex("PhoneId");

                    b.HasIndex("PhoneTypeId");

                    b.HasIndex("JuvenileId", "AdultId");

                    b.ToTable("MemberPhone");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.PhoneType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("PhoneType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("InActive");

                    b.Property<DateTime?>("InActiveDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Address", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.AddrType", "AddrType")
                        .WithMany("Address")
                        .HasForeignKey("AddrTypeId")
                        .HasConstraintName("FK_Address_AddressType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.AdultMemberAddress", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.Address", "Address")
                        .WithMany("AdultMemberAddress")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_MemberAddress_Address");

                    b.HasOne("WebApplication4.Models.LibraryModels.AdultMember", "Adult")
                        .WithMany("AdultMemberAddress")
                        .HasForeignKey("AdultId")
                        .HasConstraintName("FK_MemberAddress_AdultMember");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.CheckOut", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.AdultMember", "Adult")
                        .WithMany("CheckOut")
                        .HasForeignKey("AdultId")
                        .HasConstraintName("FK_AdultCheckOut_AdultMember");

                    b.HasOne("WebApplication4.Models.LibraryModels.MediaCopy", "MediaCopy")
                        .WithMany("CheckOut")
                        .HasForeignKey("MediaCopyId")
                        .HasConstraintName("FK_AdultCheckOut_MediaCopy");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.JuvenileMember", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.AdultMember", "Adult")
                        .WithMany("JuvenileMember")
                        .HasForeignKey("AdultId")
                        .HasConstraintName("FK_JuvenileMember_AdultMember");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.Media", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.Publisher", "Publisher")
                        .WithMany("Media")
                        .HasForeignKey("PublisherId")
                        .HasConstraintName("FK_Media_Publisher");

                    b.HasOne("WebApplication4.Models.LibraryModels.Series", "Series")
                        .WithMany("Media")
                        .HasForeignKey("SeriesId")
                        .HasConstraintName("FK_Media_SeriesId");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaContent", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.Media", "Media")
                        .WithMany("MediaContent")
                        .HasForeignKey("MediaId")
                        .HasConstraintName("FK_MediaContent_Media");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaCopy", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.MediaFormat", "MediaFormat")
                        .WithMany("MediaCopy")
                        .HasForeignKey("MediaFormatId")
                        .HasConstraintName("FK_MediaCopy_MeidaFormat");

                    b.HasOne("WebApplication4.Models.LibraryModels.Genre", "MediaGenre")
                        .WithMany("MediaCopy")
                        .HasForeignKey("MediaGenreId")
                        .HasConstraintName("FK_MediaCopy_Genre");

                    b.HasOne("WebApplication4.Models.LibraryModels.Media", "Media")
                        .WithMany("MediaCopy")
                        .HasForeignKey("MediaId")
                        .HasConstraintName("FK_MediaCopy_Media");

                    b.HasOne("WebApplication4.Models.LibraryModels.MediaType", "MediaType")
                        .WithMany("MediaCopy")
                        .HasForeignKey("MediaTypeId")
                        .HasConstraintName("FK_MediaCopy_MediaType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaTypeFormat", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.MediaFormat", "MediaFormat")
                        .WithMany("MediaTypeFormat")
                        .HasForeignKey("MediaFormatId")
                        .HasConstraintName("FK_TypeFormat_Genre");

                    b.HasOne("WebApplication4.Models.LibraryModels.MediaType", "MediaType")
                        .WithMany("MediaTypeFormat")
                        .HasForeignKey("MediaTypeId")
                        .HasConstraintName("FK_TypeFormat_Format");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MediaTypeGenre", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.Genre", "Genre")
                        .WithMany("MediaTypeGenre")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TypeGenre_Genre");

                    b.HasOne("WebApplication4.Models.LibraryModels.MediaType", "MediaType")
                        .WithMany("MediaTypeGenre")
                        .HasForeignKey("MediaTypeId")
                        .HasConstraintName("FK_TypeGenre_MediaType");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MemberEmail", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.AdultMember", "Adult")
                        .WithMany("MemberEmail")
                        .HasForeignKey("AdultId")
                        .HasConstraintName("FK_MemberEmail_AdultMember");

                    b.HasOne("WebApplication4.Models.LibraryModels.Email", "Email")
                        .WithMany("MemberEmail")
                        .HasForeignKey("EmailId")
                        .HasConstraintName("FK_MemberEmail_Email");

                    b.HasOne("WebApplication4.Models.LibraryModels.JuvenileMember", "JuvenileMember")
                        .WithMany("MemberEmail")
                        .HasForeignKey("JuvenileId", "AdultId")
                        .HasConstraintName("FK_MemberEmail_JuvenileMember");
                });

            modelBuilder.Entity("WebApplication4.Models.LibraryModels.MemberPhone", b =>
                {
                    b.HasOne("WebApplication4.Models.LibraryModels.AdultMember", "Adult")
                        .WithMany("MemberPhone")
                        .HasForeignKey("AdultId")
                        .HasConstraintName("FK_MemberPhone_AdultMember");

                    b.HasOne("WebApplication4.Models.LibraryModels.Phone", "Phone")
                        .WithMany("MemberPhone")
                        .HasForeignKey("PhoneId")
                        .HasConstraintName("FK_MemberPhone_Phone");

                    b.HasOne("WebApplication4.Models.LibraryModels.PhoneType", "PhoneType")
                        .WithMany("MemberPhone")
                        .HasForeignKey("PhoneTypeId")
                        .HasConstraintName("FK_MemberPhone_PhoneType");

                    b.HasOne("WebApplication4.Models.LibraryModels.JuvenileMember", "JuvenileMember")
                        .WithMany("MemberPhone")
                        .HasForeignKey("JuvenileId", "AdultId")
                        .HasConstraintName("FK_MemberPhone_JuvenileMember");
                });
#pragma warning restore 612, 618
        }
    }
}