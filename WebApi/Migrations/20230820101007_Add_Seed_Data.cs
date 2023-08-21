using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sci-Fi" },
                    { 2, "Horror" },
                    { 3, "Action" },
                    { 4, "Adventure" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DurationAsMinute", "IsReleased", "LastModified", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 119, true, null, new DateTime(1982, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Thing" },
                    { 2, 120, true, null, new DateTime(1941, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Citizen Kane" },
                    { 3, 99, true, null, new DateTime(1981, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escape From New York" },
                    { 4, 207, true, null, new DateTime(1954, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seven Samurai" },
                    { 5, 100, true, null, new DateTime(1998, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark City" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
