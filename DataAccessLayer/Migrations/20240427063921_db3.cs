using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1eb34f-4466-4d68-bc4b-66ffa58605e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f47ff40b-26c1-4012-a514-107d1e9bb414");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink",
                table: "ImageData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifieBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a7b4e35-cb31-4a8a-ace5-1f9059389123", null, "Client", "Client" },
                    { "55b353f7-afd4-4045-a3f1-20efa2d0ac00", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a7b4e35-cb31-4a8a-ace5-1f9059389123");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55b353f7-afd4-4045-a3f1-20efa2d0ac00");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifieBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifieDate",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLink",
                table: "ImageData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e1eb34f-4466-4d68-bc4b-66ffa58605e8", null, "Admin", "Admin" },
                    { "f47ff40b-26c1-4012-a514-107d1e9bb414", null, "Client", "Client" }
                });
        }
    }
}
