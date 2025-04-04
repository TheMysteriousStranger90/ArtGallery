using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixPaintingImageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7262));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 7, 53, 28, 208, DateTimeKind.Utc).AddTicks(7069));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
