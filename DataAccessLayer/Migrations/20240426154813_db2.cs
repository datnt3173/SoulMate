using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21749d45-f2ce-4387-b4b2-cbe766e65a4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "428b3a8c-0dd4-48c1-84d7-65e85bb8caa9");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Information",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstAndLastName",
                table: "Information",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76dc454c-2325-4ce2-84bc-149b4526641a", null, "Client", "Client" },
                    { "e1b82088-ee56-4040-b1af-cab896a26073", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76dc454c-2325-4ce2-84bc-149b4526641a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1b82088-ee56-4040-b1af-cab896a26073");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "FirstAndLastName",
                table: "Information");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21749d45-f2ce-4387-b4b2-cbe766e65a4a", null, "Client", "Client" },
                    { "428b3a8c-0dd4-48c1-84d7-65e85bb8caa9", null, "Admin", "Admin" }
                });
        }
    }
}
