using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Jwt_for_User_Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a940a91a-c4b2-4be5-878d-25b3e9e55621");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32eea00-5230-4e0a-9c9f-f5b169decf22");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ee3c2cd-06aa-411d-853a-e55dbc9bc1c6", "28492792-181b-46db-9fc7-068e0d46fb50", "Admin", "ADMIN" },
                    { "5d787afb-c171-4e62-ba14-5df010a5c28d", "b173085b-e29e-40c6-b736-a9fbfdbd6bac", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ee3c2cd-06aa-411d-853a-e55dbc9bc1c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d787afb-c171-4e62-ba14-5df010a5c28d");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a940a91a-c4b2-4be5-878d-25b3e9e55621", "7fcff81d-f8f3-477c-aecc-c0154a606c23", "Admin", "ADMIN" },
                    { "c32eea00-5230-4e0a-9c9f-f5b169decf22", "54d186fb-69b4-4a17-b452-2fe2cfaadfe6", "User", "USER" }
                });
        }
    }
}
