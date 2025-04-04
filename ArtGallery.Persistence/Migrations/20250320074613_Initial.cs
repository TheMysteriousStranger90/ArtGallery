using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistImages_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biographies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    References = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biographies_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteArtist",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteArtist", x => new { x.UserId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteArtist_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteArtist_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Museums_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalVenueAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuseumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exhibitions_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Paintings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreationYear = table.Column<int>(type: "int", nullable: false),
                    Medium = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PaintType = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MuseumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paintings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paintings_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paintings_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Paintings_Museums_MuseumId",
                        column: x => x.MuseumId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PaintingExhibitions",
                columns: table => new
                {
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingExhibitions", x => new { x.PaintingId, x.ExhibitionId });
                    table.ForeignKey(
                        name: "FK_PaintingExhibitions_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingExhibitions_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaintingImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaintingImages_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaintingTags",
                columns: table => new
                {
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingTags", x => new { x.PaintingId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PaintingTags_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoritePainting",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaintingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoritePainting", x => new { x.UserId, x.PaintingId });
                    table.ForeignKey(
                        name: "FK_UserFavoritePainting_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoritePainting_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "CreatedDate", "DeathDate", "FirstName", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "LastName", "Nationality" },
                values: new object[,]
                {
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"), new DateTime(1848, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8514), new DateTime(1926, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viktor", false, null, null, "Vasnetsov", "Russian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"), new DateTime(1856, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8519), new DateTime(1910, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikhail", false, null, null, "Vrubel", "Russian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"), new DateTime(1817, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8522), new DateTime(1900, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", false, null, null, "Aivazovsky", "Russian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"), new DateTime(1830, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8525), new DateTime(1897, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexei", false, null, null, "Savrasov", "Russian" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"), "RU", null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7504), false, null, null, "Russia" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8374), "Art depicting scenes from mythology or folklore", false, null, null, "Mythological Art" },
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8377), "Art depicting natural scenery, such as mountains, valleys, trees, rivers, and forests", false, null, null, "Landscape" },
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8379), "Art depicting the sea or maritime scenes", false, null, null, "Seascape" },
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8381), "Art that emphasizes the expression of ideas through symbols", false, null, null, "Symbolism" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8431), false, null, null, "Russian Art" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8434), false, null, null, "19th Century" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8437), false, null, null, "Early 20th Century" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8439), false, null, null, "Romanticism" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8441), false, null, null, "Folklore" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8462), false, null, null, "Sea" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8463), false, null, null, "Spring" }
                });

            migrationBuilder.InsertData(
                table: "ArtistImages",
                columns: new[] { "Id", "ArtistId", "CreatedBy", "CreatedDate", "IsDeleted", "IsMain", "LastModifiedBy", "LastModifiedDate", "PictureUrl", "PublicId" },
                values: new object[,]
                {
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8665), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/2/29/Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg", "artist_vasnetsov" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8669), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/7/7f/Vrubel_Self-Portrait_1882.jpg", "artist_vrubel" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8671), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/b/b5/Aivazovsky_-_Self-portrait_1874.jpg", "artist_aivazovsky" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8673), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/9/9f/Alexey_Savrasov.jpg", "artist_savrasov" }
                });

            migrationBuilder.InsertData(
                table: "Biographies",
                columns: new[] { "Id", "ArtistId", "Content", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "References", "ShortDescription" },
                values: new object[,]
                {
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"), "Viktor Mikhailovich Vasnetsov was a Russian painter who specialized in mythological and historical subjects. He is considered the co-founder of Russian folklorist and romantic nationalistic painting and a key figure in the Russian revivalist movement. His notable works include After Prince Igor's Battle with the Polovtsy, Knight at the Crossroads, Bogatyrs, and Alyonushka.", null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8614), false, null, null, "Korotkevich, V.N. Viktor Vasnetsov: The Artist's Work. Leningrad, 1962.", "One of the key figures in the Russian revivalist movement" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"), "Mikhail Aleksandrovich Vrubel was a Russian painter who specialized in symbolist paintings of mythological themes. His contemporaries often saw him as strange and mentally unstable due to his unique style of painting. At the time of his death, Vrubel was among the most controversial painters in Russian art. His innovative art is now considered a bridge connecting the traditional art of the 19th century with the modernism of the 20th century.", null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8619), false, null, null, "Gomberg-Verzhbinskaia, E.P. Vrubel. Moscow, 1959.", "A Russian symbolist painter known for his unusual style and technique" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"), "Ivan Konstantinovich Aivazovsky was a Russian Romantic painter who is considered one of the greatest masters of marine art. He was born into an Armenian family in the town of Feodosia in Crimea and was mostly known for his seascapes, which constitute more than half of his paintings. During his almost 60-year career, he created around 6,000 paintings, making him one of the most prolific artists of his time.", null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8622), false, null, null, "Caffiero, G., Samarine, I. Seas, Cities & Dreams: The Paintings of Ivan Aivazovsky. London, 2000.", "One of the greatest masters of marine art in history" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"), "Alexei Kondratyevich Savrasov was a Russian landscape painter and creator of the 'mood landscape' genre. He is credited with developing the lyrical landscape style, and his painting The Rooks Have Come Back (1871) is considered one of the most significant works of Russian landscape painting. Savrasov's life was marked by personal tragedy and alcoholism in his later years, but his influence on Russian landscape painting was immense.", null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8625), false, null, null, "Novouspensky, N. Alexei Savrasov. Leningrad, 1982.", "Founder of the lyrical landscape style in Russian painting" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"), new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7691), false, null, null, "Moscow" },
                    { new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"), new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7694), false, null, null, "Saint Petersburg" }
                });

            migrationBuilder.InsertData(
                table: "Museums",
                columns: new[] { "Id", "Address", "CityId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), "Lavrushinsky Ln, 10, Moscow, Russia, 119017", new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7730), "The State Tretyakov Gallery is an art gallery in Moscow, Russia, the foremost depository of Russian fine art in the world.", false, null, null, "The State Tretyakov Gallery", "https://www.tretyakovgallery.ru/en/" },
                    { new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"), "Inzhenernaya St, 4, St Petersburg, Russia, 191186", new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7733), "The State Russian Museum is the world's largest depository of Russian fine art. It is also one of the largest museums in the country.", false, null, null, "The State Russian Museum", "https://rusmuseum.ru/en/" }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "Id", "ArtistId", "CreatedBy", "CreatedDate", "CreationYear", "Description", "Dimensions", "GenreId", "ImageUrl", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Medium", "MuseumId", "PaintType", "Title" },
                values: new object[,]
                {
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8711), 1898, "Also known as Three Bogatyrs, this painting depicts three of the most legendary bogatyrs (medieval Russian knights): Dobrynya Nikitich, Ilya Muromets and Alyosha Popovich. They are portrayed on patrol together in the frontier of the Russian land.", "295.3 cm × 446 cm (116.3 in × 175.6 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"), "https://upload.wikimedia.org/wikipedia/commons/4/4e/Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "Bogatyrs" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8718), 1881, "A painting depicting a young woman, Alyonushka, a character from Russian folk tales, sitting forlornly by a pond. The painting is notable for its depiction of the Russian landscape and its melancholic mood.", "177 cm × 121 cm (69.7 in × 47.6 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"), "https://upload.wikimedia.org/wikipedia/commons/9/97/Vasnetsov_Alionushka.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "Alyonushka" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8722), 1890, "One of Vrubel's most famous works, depicting a winged demon sitting in a pensive pose. The painting is characterized by its unusual crystalline form and vibrant colors.", "114 cm × 211 cm (44.9 in × 83.1 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"), "https://upload.wikimedia.org/wikipedia/commons/b/bf/Vrubel_Demon.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "Demon Seated" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8727), 1902, "The last of Vrubel's Demon series, showing the defeated demon with broken wings. This painting is associated with the deterioration of Vrubel's mental health.", "139 cm × 387 cm (54.7 in × 152.4 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"), "https://upload.wikimedia.org/wikipedia/commons/f/fc/Vrubel_Fallen_Demon.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "Demon Downcast" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8735), 1850, "Aivazovsky's most famous painting, showing a group of people clinging to debris from a shipwreck, facing a large wave at sunrise. The title refers to the nautical belief that the ninth wave is the largest in a series of waves.", "221 cm × 332 cm (87.0 in × 130.7 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"), "https://upload.wikimedia.org/wikipedia/commons/4/4a/Hovhannes_Aivazovsky_-_The_Ninth_Wave_-_Google_Art_Project.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"), 0, "The Ninth Wave" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8742), 1849, "A dramatic seascape depicting a violent storm at night, with a ship struggling against massive waves. The painting showcases Aivazovsky's mastery in depicting light and water.", "100 cm × 141 cm (39.4 in × 55.5 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"), "https://upload.wikimedia.org/wikipedia/commons/5/51/Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"), 0, "Storm on the Sea at Night" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8747), 1871, "Savrasov's most famous work, depicting the early spring landscape with rooks nesting in birch trees. The painting conveys the sense of awakening nature and hope.", "62 cm × 48.5 cm (24.4 in × 19.1 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"), "https://upload.wikimedia.org/wikipedia/commons/3/30/Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "The Rooks Have Returned" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"), null, new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8752), 1873, "A serene landscape depicting a countryside road in rural Russia. The painting demonstrates Savrasov's talent for capturing the subtle poetry of simple Russian landscapes.", "58.8 cm × 80.5 cm (23.1 in × 31.7 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"), "https://upload.wikimedia.org/wikipedia/commons/7/7a/Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"), 0, "Countryside Road" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistImages_ArtistId",
                table: "ArtistImages",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Biographies_ArtistId",
                table: "Biographies",
                column: "ArtistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_MuseumId",
                table: "Exhibitions",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_Museums_CityId",
                table: "Museums",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingExhibitions_ExhibitionId",
                table: "PaintingExhibitions",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingImages_PaintingId",
                table: "PaintingImages",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_ArtistId",
                table: "Paintings",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_GenreId",
                table: "Paintings",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Paintings_MuseumId",
                table: "Paintings",
                column: "MuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingTags_TagId",
                table: "PaintingTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteArtist_ArtistId",
                table: "UserFavoriteArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritePainting_PaintingId",
                table: "UserFavoritePainting",
                column: "PaintingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistImages");

            migrationBuilder.DropTable(
                name: "Biographies");

            migrationBuilder.DropTable(
                name: "PaintingExhibitions");

            migrationBuilder.DropTable(
                name: "PaintingImages");

            migrationBuilder.DropTable(
                name: "PaintingTags");

            migrationBuilder.DropTable(
                name: "UserFavoriteArtist");

            migrationBuilder.DropTable(
                name: "UserFavoritePainting");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Paintings");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Museums");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
