using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NW_Central_Library.Migrations
{
    public partial class inti_LibProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LibraryDesc = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    LibraryName = table.Column<string>(unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddrType",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddrType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AdultMember",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MidInit = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Suffix = table.Column<string>(unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultMember", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Addr = table.Column<string>(unicode: false, maxLength: 90, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MediaFormat",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    Format = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFormat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    PhoneNum = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneType",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddrLn1 = table.Column<string>(unicode: false, maxLength: 90, nullable: false),
                    AddrLn2 = table.Column<string>(unicode: false, maxLength: 90, nullable: true),
                    AddrTypeID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    Zip = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_AddressType",
                        column: x => x.AddrTypeID,
                        principalTable: "AddrType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JuvenileMember",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdultID = table.Column<int>(nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MidInit = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Suffix = table.Column<string>(unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuvenileMember", x => new { x.ID, x.AdultID });
                    table.ForeignKey(
                        name: "FK_JuvenileMember_AdultMember",
                        column: x => x.AdultID,
                        principalTable: "AdultMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypeFormat",
                columns: table => new
                {
                    MediaTypeID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    MediaFormatID = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypeFormat", x => new { x.MediaTypeID, x.MediaFormatID });
                    table.ForeignKey(
                        name: "FK_TypeFormat_Genre",
                        column: x => x.MediaFormatID,
                        principalTable: "MediaFormat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeFormat_Format",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypeGenre",
                columns: table => new
                {
                    MediaTypeID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    GenreID = table.Column<string>(unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypeGenre", x => new { x.MediaTypeID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_TypeGenre_Genre",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeGenre_MediaType",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(unicode: false, maxLength: 90, nullable: false),
                    Characteristics = table.Column<string>(unicode: false, maxLength: 90, nullable: false),
                    CopyRightDate = table.Column<DateTime>(type: "date", nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    PublisherID = table.Column<int>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Media_Publisher",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdultMemberAddress",
                columns: table => new
                {
                    AdultID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultMemberAddress", x => new { x.AdultID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_MemberAddress_Address",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberAddress_AdultMember",
                        column: x => x.AdultID,
                        principalTable: "AdultMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberEmail",
                columns: table => new
                {
                    AdultID = table.Column<int>(nullable: false),
                    EmailID = table.Column<int>(nullable: false),
                    JuvenileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEmail", x => new { x.AdultID, x.EmailID });
                    table.ForeignKey(
                        name: "FK_MemberEmail_AdultMember",
                        column: x => x.AdultID,
                        principalTable: "AdultMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberEmail_Email",
                        column: x => x.EmailID,
                        principalTable: "Email",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberEmail_JuvenileMember",
                        columns: x => new { x.JuvenileID, x.AdultID },
                        principalTable: "JuvenileMember",
                        principalColumns: new[] { "ID", "AdultID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberPhone",
                columns: table => new
                {
                    AdultID = table.Column<int>(nullable: false),
                    PhoneID = table.Column<int>(nullable: false),
                    JuvenileID = table.Column<int>(nullable: true),
                    PhoneTypeID = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberPhone", x => new { x.AdultID, x.PhoneID });
                    table.ForeignKey(
                        name: "FK_MemberPhone_AdultMember",
                        column: x => x.AdultID,
                        principalTable: "AdultMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPhone_Phone",
                        column: x => x.PhoneID,
                        principalTable: "Phone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPhone_PhoneType",
                        column: x => x.PhoneTypeID,
                        principalTable: "PhoneType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberPhone_JuvenileMember",
                        columns: x => new { x.JuvenileID, x.AdultID },
                        principalTable: "JuvenileMember",
                        principalColumns: new[] { "ID", "AdultID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaContent",
                columns: table => new
                {
                    ContentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentItem = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ContentItemOrder = table.Column<int>(nullable: false),
                    MediaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContent", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK_MediaContent_Media",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaCopy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CopyNumber = table.Column<int>(nullable: false),
                    InActive = table.Column<bool>(nullable: true),
                    InActiveDate = table.Column<DateTime>(type: "date", nullable: true),
                    MediaFormatID = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    MediaGenreID = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    MediaID = table.Column<int>(nullable: false),
                    MediaTypeID = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaCopy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MediaCopy_MeidaFormat",
                        column: x => x.MediaFormatID,
                        principalTable: "MediaFormat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaCopy_Genre",
                        column: x => x.MediaGenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaCopy_Media",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaCopy_MediaType",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckOut",
                columns: table => new
                {
                    AdultID = table.Column<int>(nullable: false),
                    MediaCopyID = table.Column<int>(nullable: false),
                    CheckedInDate = table.Column<DateTime>(type: "date", nullable: true),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    JuvenileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOut", x => new { x.AdultID, x.MediaCopyID });
                    table.ForeignKey(
                        name: "FK_AdultCheckOut_AdultMember",
                        column: x => x.AdultID,
                        principalTable: "AdultMember",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdultCheckOut_MediaCopy",
                        column: x => x.MediaCopyID,
                        principalTable: "MediaCopy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddrTypeID",
                table: "Address",
                column: "AddrTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AdultMemberAddress_AddressID",
                table: "AdultMemberAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOut_MediaCopyID",
                table: "CheckOut",
                column: "MediaCopyID");

            migrationBuilder.CreateIndex(
                name: "IX_JuvenileMember_AdultID",
                table: "JuvenileMember",
                column: "AdultID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PublisherID",
                table: "Media",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_SeriesId",
                table: "Media",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaContent_MediaID",
                table: "MediaContent",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCopy_MediaFormatID",
                table: "MediaCopy",
                column: "MediaFormatID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCopy_MediaGenreID",
                table: "MediaCopy",
                column: "MediaGenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCopy_MediaID",
                table: "MediaCopy",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaCopy_MediaTypeID",
                table: "MediaCopy",
                column: "MediaTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypeFormat_MediaFormatID",
                table: "MediaTypeFormat",
                column: "MediaFormatID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypeGenre_GenreID",
                table: "MediaTypeGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEmail_EmailID",
                table: "MemberEmail",
                column: "EmailID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEmail_JuvenileID_AdultID",
                table: "MemberEmail",
                columns: new[] { "JuvenileID", "AdultID" });

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhone_PhoneID",
                table: "MemberPhone",
                column: "PhoneID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhone_PhoneTypeID",
                table: "MemberPhone",
                column: "PhoneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberPhone_JuvenileID_AdultID",
                table: "MemberPhone",
                columns: new[] { "JuvenileID", "AdultID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "AdultMemberAddress");

            migrationBuilder.DropTable(
                name: "CheckOut");

            migrationBuilder.DropTable(
                name: "MediaContent");

            migrationBuilder.DropTable(
                name: "MediaTypeFormat");

            migrationBuilder.DropTable(
                name: "MediaTypeGenre");

            migrationBuilder.DropTable(
                name: "MemberEmail");

            migrationBuilder.DropTable(
                name: "MemberPhone");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "MediaCopy");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "PhoneType");

            migrationBuilder.DropTable(
                name: "JuvenileMember");

            migrationBuilder.DropTable(
                name: "AddrType");

            migrationBuilder.DropTable(
                name: "MediaFormat");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "AdultMember");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
