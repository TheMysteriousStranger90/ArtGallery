using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtGallery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewPainters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "CreatedDate", "DeathDate", "FirstName", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "LastName", "Nationality" },
                values: new object[,]
                {
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"), new DateTime(1452, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7252), new DateTime(1519, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leonardo", false, null, null, "da Vinci", "Italian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"), new DateTime(1475, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7257), new DateTime(1564, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michelangelo", false, null, null, "Buonarroti", "Italian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"), new DateTime(1445, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7275), new DateTime(1510, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sandro", false, null, null, "Botticelli", "Italian" },
                    { new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"), new DateTime(1571, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7279), new DateTime(1610, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michelangelo Merisi", false, null, null, "da Caravaggio", "Italian" }
                });

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
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"), "IT", null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6215), false, null, null, "Italy" });

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

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21205"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6988), "Art from the Renaissance period characterized by realistic depiction and classical themes", false, null, null, "Renaissance" },
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6993), "Art depicting religious themes and biblical scenes", false, null, null, "Religious Art" },
                    { new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6995), "Art depicting individual persons or groups of people", false, null, null, "Portrait" }
                });

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
                column: "CreatedDate",
                value: new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7636));

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

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7121), false, null, null, "Italian Art" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7126), false, null, null, "Renaissance" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7131), false, null, null, "Classical" },
                    { new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7133), false, null, null, "Baroque" }
                });

            migrationBuilder.InsertData(
                table: "ArtistImages",
                columns: new[] { "Id", "ArtistId", "CreatedBy", "CreatedDate", "IsDeleted", "IsMain", "LastModifiedBy", "LastModifiedDate", "PictureUrl", "PublicId" },
                values: new object[,]
                {
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21220"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7483), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Leonardo_self.jpg/256px-Leonardo_self.jpg", "artist_davinci" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21221"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7489), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Miguel_%C3%81ngel%2C_por_Daniele_da_Volterra_%28detalle%29.jpg/256px-Miguel_%C3%81ngel%2C_por_Daniele_da_Volterra_%28detalle%29.jpg", "artist_michelangelo" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21222"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7494), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Sandro_Botticelli_083.jpg/256px-Sandro_Botticelli_083.jpg", "artist_botticelli" },
                    { new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21223"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7497), false, true, null, null, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Bild-Ottavio_Leoni%2C_Caravaggio.jpg/256px-Bild-Ottavio_Leoni%2C_Caravaggio.jpg", "artist_caravaggio" }
                });

            migrationBuilder.InsertData(
                table: "Biographies",
                columns: new[] { "Id", "ArtistId", "Content", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "References", "ShortDescription" },
                values: new object[,]
                {
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21216"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"), "Leonardo da Vinci was an Italian polymath of the High Renaissance who was active as a painter, draughtsman, engineer, scientist, theorist, sculptor and architect. While his fame initially rested on his achievements as a painter, he also became known for his notebooks, in which he made drawings and notes on science and invention. These involved a variety of subjects including anatomy, astronomy, botany, cartography, painting, and paleontology.", null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7368), false, null, null, "Kemp, Martin. Leonardo da Vinci: The Marvellous Works of Nature and Man. Oxford, 2006.", "Renaissance polymath and painter of the Mona Lisa" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21217"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"), "Michelangelo di Lodovico Buonarroti Simoni was an Italian sculptor, painter, architect, and poet of the High Renaissance. Born in the Republic of Florence, his work exerted an unparalleled influence on the development of Western art. Considered the greatest living artist during his lifetime, he has since been described as one of the greatest artists of all time.", null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7372), false, null, null, "Wallace, William E. Michelangelo: The Artist, the Man and His Times. Cambridge, 2010.", "Renaissance master sculptor and painter of the Sistine Chapel" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21218"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"), "Alessandro di Mariano di Vanni Filipepi, known as Sandro Botticelli, was an Italian painter of the Early Renaissance. Botticelli's posthumous reputation suffered until the late 19th century, when he was rediscovered by the Pre-Raphaelites who stimulated a reappraisal of his work. Since then, his paintings have been seen to represent the linear grace of Early Renaissance painting.", null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7378), false, null, null, "Lightbown, Ronald. Sandro Botticelli: Life and Work. London, 1989.", "Early Renaissance painter famous for The Birth of Venus" },
                    { new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21219"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"), "Michelangelo Merisi da Caravaggio was an Italian painter active in Rome for most of his artistic life. During the final four years of his life he moved between Naples, Malta, and Sicily until his death. His paintings have been characterized by art critics as combining a realistic observation of the human state, both physical and emotional, with a dramatic use of lighting.", null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7382), false, null, null, "Langdon, Helen. Caravaggio: A Life. New York, 1998.", "Baroque painter renowned for his revolutionary use of light and shadow" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedDate", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"), new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6812), false, null, null, "Florence" },
                    { new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"), new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6817), false, null, null, "Rome" }
                });

            migrationBuilder.InsertData(
                table: "Museums",
                columns: new[] { "Id", "Address", "CityId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Name", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"), "Piazzale degli Uffizi, 6, 50122 Firenze FI, Italy", new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6914), "The Uffizi Gallery is a prominent art museum located adjacent to the Piazza della Signoria in the Historic Centre of Florence in the region of Tuscany, Italy.", false, null, null, "Uffizi Gallery", "https://www.uffizi.it/en" },
                    { new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"), "00120 Vatican City", new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(6919), "The Vatican Museums are the public museums of the Vatican City. They display works from the immense collection amassed by the Catholic Church and the papacy throughout the centuries.", false, null, null, "Vatican Museums", "https://www.museivaticani.va/" }
                });

            migrationBuilder.InsertData(
                table: "Paintings",
                columns: new[] { "Id", "ArtistId", "CreatedBy", "CreatedDate", "CreationYear", "Description", "Dimensions", "GenreId", "ImageUrl", "IsDeleted", "LastModifiedBy", "LastModifiedDate", "Medium", "MuseumId", "PaintType", "Title" },
                values: new object[,]
                {
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7678), 1503, "The Mona Lisa is a half-length portrait painting by Italian artist Leonardo da Vinci. Considered an archetypal masterpiece of the Italian Renaissance, it has been described as 'the best known, the most visited, the most written about, the most sung about, the most parodied work of art in the world'.", "77 cm × 53 cm (30 in × 21 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"), "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/687px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg", false, null, null, "Oil on poplar panel", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"), 0, "Mona Lisa" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21225"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7687), 1498, "The Last Supper is a mural painting by Italian High Renaissance Leonardo da Vinci housed by the refectory of the Convent of Santa Maria delle Grazie in Milan, Italy. It depicts the scene of the Last Supper of Jesus with his apostles.", "460 cm × 880 cm (181 in × 346 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/%C3%9Altima_Cena_-_Da_Vinci_5.jpg/800px-%C3%9Altima_Cena_-_Da_Vinci_5.jpg", false, null, null, "Tempera and oil on gesso", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"), 4, "The Last Supper" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21226"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7695), 1512, "The Creation of Adam is a fresco painting by Italian artist Michelangelo, which forms part of the Sistine Chapel's ceiling, painted c. 1508–1512. It illustrates the Biblical creation narrative from the Book of Genesis in which God gives life to Adam, the first man.", "280 cm × 570 cm (110 in × 224 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), "https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Creaci%C3%B3n_de_Ad%C3%A1m.jpg/800px-Creaci%C3%B3n_de_Ad%C3%A1m.jpg", false, null, null, "Fresco", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"), 7, "The Creation of Adam" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21227"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7701), 1541, "The Last Judgment is a fresco by the Italian Renaissance painter Michelangelo covering the whole altar wall of the Sistine Chapel in Vatican City. It is a depiction of the Second Coming of Christ and the final and eternal judgment by God of all humanity.", "1370 cm × 1200 cm (539 in × 472 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Last_Judgement_%28Michelangelo%29.jpg/600px-Last_Judgement_%28Michelangelo%29.jpg", false, null, null, "Fresco", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"), 7, "The Last Judgment" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7708), 1485, "The Birth of Venus is a painting by Italian artist Sandro Botticelli, probably executed in the mid 1480s. It depicts the goddess Venus arriving at the shore after her birth, when she had emerged from the sea fully-grown.", "172.5 cm × 278.9 cm (67.9 in × 109.6 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg/800px-Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg", false, null, null, "Tempera on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"), 4, "The Birth of Venus" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21229"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7715), 1482, "Primavera, also known as Allegory of Spring, is a large panel painting in tempera paint by the Italian Renaissance painter Sandro Botticelli made in the late 1470s or early 1480s. The painting has been described as one of the most written about, and most controversial paintings in the world.", "202 cm × 314 cm (80 in × 124 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21111"), "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Botticelli-primavera.jpg/800px-Botticelli-primavera.jpg", false, null, null, "Tempera on wood", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"), 4, "Primavera" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7722), 1600, "The Calling of Saint Matthew is a masterpiece by Michelangelo Merisi da Caravaggio, depicting the moment when Jesus Christ inspires Matthew to follow him. It was completed in 1599-1600 for the Contarelli Chapel in the church of the French congregation San Luigi dei Francesi in Rome.", "322 cm × 340 cm (127 in × 134 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), "https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/The_Calling_of_Saint_Matthew-Caravaggo_%281599-1600%29.jpg/800px-The_Calling_of_Saint_Matthew-Caravaggo_%281599-1600%29.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"), 0, "The Calling of Saint Matthew" },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21231"), new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7728), 1602, "Judith Beheading Holofernes is a painting by the Italian early Baroque artist Caravaggio, painted in 1598-1602. The painting depicts Judith beheading Holofernes, a scene from the deuterocanonical Book of Judith in the Old Testament.", "144 cm × 195 cm (57 in × 77 in)", new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"), "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Caravaggio_Judith_Beheading_Holofernes.jpg/800px-Caravaggio_Judith_Beheading_Holofernes.jpg", false, null, null, "Oil on canvas", new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"), 0, "Judith Beheading Holofernes" }
                });

            migrationBuilder.InsertData(
                table: "PaintingTags",
                columns: new[] { "PaintingId", "TagId", "CreatedBy", "CreatedDate", "Id", "IsDeleted", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7846), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21232"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7851), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21233"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7857), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21234"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7861), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21235"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7869), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21236"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7872), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21237"), false, null, null },
                    { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"), null, new DateTime(2025, 6, 7, 12, 1, 17, 100, DateTimeKind.Utc).AddTicks(7891), new Guid("2c6aeae0-5c40-4085-8993-7d7b5db21238"), false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21220"));

            migrationBuilder.DeleteData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21221"));

            migrationBuilder.DeleteData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21222"));

            migrationBuilder.DeleteData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21223"));

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21216"));

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21217"));

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21218"));

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: new Guid("fc6aeae0-5c40-4085-8993-7d7b5db21219"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21205"));

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208") });

            migrationBuilder.DeleteData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211") });

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21225"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21226"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21227"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21229"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21231"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21213"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21224"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21228"));

            migrationBuilder.DeleteData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21230"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21208"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21209"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21210"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21211"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21212"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21214"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("ec6aeae0-5c40-4085-8993-7d7b5db21215"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21206"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cc6aeae0-5c40-4085-8993-7d7b5db21207"));

            migrationBuilder.DeleteData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21203"));

            migrationBuilder.DeleteData(
                table: "Museums",
                keyColumn: "Id",
                keyValue: new Guid("bc6aeae0-5c40-4085-8993-7d7b5db21204"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21201"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9c6aeae0-5c40-4085-8993-7d7b5db21202"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("8c6aeae0-5c40-4085-8993-7d7b5db21200"));

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1399), "https://upload.wikimedia.org/wikipedia/commons/2/29/Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1404), "https://upload.wikimedia.org/wikipedia/commons/7/7f/Vrubel_Self-Portrait_1882.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1406), "https://upload.wikimedia.org/wikipedia/commons/b/b5/Aivazovsky_-_Self-portrait_1874.jpg" });

            migrationBuilder.UpdateData(
                table: "ArtistImages",
                keyColumn: "Id",
                keyValue: new Guid("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                columns: new[] { "CreatedDate", "PictureUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1409), "https://upload.wikimedia.org/wikipedia/commons/9/9f/Alexey_Savrasov.jpg" });

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

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21115") },
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21116") },
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "PaintingTags",
                keyColumns: new[] { "PaintingId", "TagId" },
                keyValues: new object[] { new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21134"), new Guid("dc6aeae0-5c40-4085-8993-7d7b5db21119") },
                column: "CreatedDate",
                value: new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.InsertData(
                table: "PaintingTags",
                columns: new[] { "PaintingId", "TagId", "CreatedBy", "CreatedDate", "Id", "IsDeleted", "LastModifiedBy", "LastModifiedDate" },
                values: new object[,]
                {
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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1452), "https://upload.wikimedia.org/wikipedia/commons/4/4e/Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1458), "https://upload.wikimedia.org/wikipedia/commons/9/97/Vasnetsov_Alionushka.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1471), "https://upload.wikimedia.org/wikipedia/commons/b/bf/Vrubel_Demon.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1477), "https://upload.wikimedia.org/wikipedia/commons/f/fc/Vrubel_Fallen_Demon.jpg" });

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
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1488), "https://upload.wikimedia.org/wikipedia/commons/5/51/Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1492), "https://upload.wikimedia.org/wikipedia/commons/3/30/Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg" });

            migrationBuilder.UpdateData(
                table: "Paintings",
                keyColumn: "Id",
                keyValue: new Guid("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 3, 31, 8, 11, 28, 57, DateTimeKind.Utc).AddTicks(1497), "https://upload.wikimedia.org/wikipedia/commons/7/7a/Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg" });

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
    }
}
