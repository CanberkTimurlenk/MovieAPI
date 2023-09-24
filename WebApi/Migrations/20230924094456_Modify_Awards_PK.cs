using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Awards_PK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Awards",
                table: "Awards");

            migrationBuilder.DropIndex(
                name: "IX_Awards_AwardTypeId",
                table: "Awards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Awards",
                table: "Awards",
                columns: new[] { "AwardTypeId", "MovieId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Awards",
                table: "Awards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Awards",
                table: "Awards",
                columns: new[] { "Date", "AwardTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardTypeId",
                table: "Awards",
                column: "AwardTypeId");
        }
    }
}
