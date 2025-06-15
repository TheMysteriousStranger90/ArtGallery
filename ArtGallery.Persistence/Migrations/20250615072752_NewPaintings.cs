using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewPaintings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5009), "https://upload.wikimedia.org/wikipedia/commons/4/4e/Wiktor_Michajlowitsch_Wassnezow_003.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5012), "https://upload.wikimedia.org/wikipedia/commons/f/fb/Mikhail_Vrubel_-_self-portrait_%281904%2C_GTG%29.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5015), "https://upload.wikimedia.org/wikipedia/commons/c/c6/Aivazovsky_-_Self-portrait_1874.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5016), "https://upload.wikimedia.org/wikipedia/commons/7/7a/Savrasov_photo.JPG" });

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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5219), "https://upload.wikimedia.org/wikipedia/commons/d/d3/Viktor_Vasnetsov_-_Богатыри_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5226), "https://upload.wikimedia.org/wikipedia/commons/3/33/Vasnetsov_Alenushka.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5231), "https://upload.wikimedia.org/wikipedia/commons/9/9f/Vrubel_Demon.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5236), "https://upload.wikimedia.org/wikipedia/commons/1/17/Vrubel_Fallen_Demon.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5241), "https://upload.wikimedia.org/wikipedia/commons/5/54/Aivazovsky%2C_Ivan_-_The_Ninth_Wave.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5246), "https://upload.wikimedia.org/wikipedia/commons/7/70/Ivan_Aivazovsky_-_Ship_in_the_Stormy_Sea.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5250), "https://upload.wikimedia.org/wikipedia/commons/1/12/RooksBackOfSavrasov.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5264), "https://upload.wikimedia.org/wikipedia/commons/7/7a/Алексей_К._Саврасов_-_Проселок_%281873%29.jpg" });

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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5278), "https://upload.wikimedia.org/wikipedia/commons/0/0c/Creation_of_Adam_Michelangelo.jpg" });

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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 15, 7, 27, 51, 383, DateTimeKind.Utc).AddTicks(5301), "https://upload.wikimedia.org/wikipedia/commons/d/df/Caravaggio_-_Giuditta_e_Oloferne_%28ca._1599%29.jpg" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7462), "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg/256px-Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7468), "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/Vrubel_Self-Portrait_1882.jpg/256px-Vrubel_Self-Portrait_1882.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7473), "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Aivazovsky_-_Self-portrait_1874.jpg/256px-Aivazovsky_-_Self-portrait_1874.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7478), "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Alexey_Savrasov.jpg/256px-Alexey_Savrasov.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21220"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21221"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21222"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21223"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7238));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21216"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21217"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21218"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21219"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21205"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211") },
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7602), "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg/800px-Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7614), "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Vasnetsov_Alionushka.jpg/600px-Vasnetsov_Alionushka.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7621), "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Vrubel_Demon.jpg/800px-Vrubel_Demon.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7629), "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Vrubel_Fallen_Demon.jpg/800px-Vrubel_Fallen_Demon.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7636), "https://upload.wikimedia.org/wikipedia/commons/4/4a/Hovhannes_Aivazovsky_-_The_Ninth_Wave_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7647), "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg/800px-Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7658), "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg/600px-Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7670), "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg/800px-Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21225"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21226"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7695), "https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Creaci%C3%B3n_de_Ad%C3%A1m.jpg/800px-Creaci%C3%B3n_de_Ad%C3%A1m.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21227"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21229"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21231"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7728), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Caravaggio_Judith_Beheading_Holofernes.jpg/800px-Caravaggio_Judith_Beheading_Holofernes.jpg" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7133));
        }
    }
}
