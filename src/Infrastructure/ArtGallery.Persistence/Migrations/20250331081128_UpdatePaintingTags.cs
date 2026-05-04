using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaintingTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(928));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1199));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1169));

            migrationBuilder.InsertData(
                table: "PaintingTags",
                columns: new[] { "PaintingId", "TagId", "CreatedBy", "CreatedDate", "Id", "IsDeleted", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1532), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21142"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1535), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21143"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1538), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21144"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1540), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21145"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1545), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21146"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1548), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21147"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1550), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21148"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1552), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21149"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1554), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21150"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1557), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21151"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1559), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21152"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1562), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21153"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1564), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21154"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1566), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21155"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1568), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21156"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1570), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21157"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1572), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21158"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1576), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21159"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"), null, new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1578), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21160"), false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1247));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1249));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") });

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
    }
}
