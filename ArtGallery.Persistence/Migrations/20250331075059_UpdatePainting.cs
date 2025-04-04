using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePainting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtist_ApplicationUser_UserId",
                table: "UserFavoriteArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoritePainting_ApplicationUser_UserId",
                table: "UserFavoritePainting");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.AddColumn<Guid>(
                name: "PaintingId1",
                table: "PaintingImages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7242));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 50, 58, 550, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.CreateIndex(
                name: "IX_PaintingImages_PaintingId1",
                table: "PaintingImages",
                column: "PaintingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PaintingImages_Paintings_PaintingId1",
                table: "PaintingImages",
                column: "PaintingId1",
                principalTable: "Paintings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaintingImages_Paintings_PaintingId1",
                table: "PaintingImages");

            migrationBuilder.DropIndex(
                name: "IX_PaintingImages_PaintingId1",
                table: "PaintingImages");

            migrationBuilder.DropColumn(
                name: "PaintingId1",
                table: "PaintingImages");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 20, 7, 46, 12, 650, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtist_ApplicationUser_UserId",
                table: "UserFavoriteArtist",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoritePainting_ApplicationUser_UserId",
                table: "UserFavoritePainting",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
