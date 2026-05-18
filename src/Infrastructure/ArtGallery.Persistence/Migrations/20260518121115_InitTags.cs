using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21220"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21221"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21222"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21223"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21216"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21217"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21218"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21219"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21205"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211") },
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21225"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21226"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21227"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21229"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21231"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1133));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"),
                column: "CreatedDate",
                value: new DateTime(2026, 5, 18, 12, 11, 14, 906, DateTimeKind.Utc).AddTicks(1154));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21220"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21221"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21222"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21223"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4866));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21216"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21217"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21218"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21219"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21205"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21225"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21226"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21227"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21229"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21231"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(4804));
        }
    }
}
