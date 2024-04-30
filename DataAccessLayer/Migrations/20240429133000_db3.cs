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
                keyValue: "bed94919-15a5-4b6b-a76a-27bed371346f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca69af81-c982-4f9a-aba2-aeb3423bc652");

            migrationBuilder.AddColumn<string>(
                name: "CodeChatRooms",
                table: "ChatRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c97d0d51-2f51-41d1-8ccb-22b533d08b2a", null, "Client", "Client" },
                    { "f9fe986d-a92b-4125-8dfa-b42f7d0bedd8", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c97d0d51-2f51-41d1-8ccb-22b533d08b2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9fe986d-a92b-4125-8dfa-b42f7d0bedd8");

            migrationBuilder.DropColumn(
                name: "CodeChatRooms",
                table: "ChatRooms");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bed94919-15a5-4b6b-a76a-27bed371346f", null, "Client", "Client" },
                    { "ca69af81-c982-4f9a-aba2-aeb3423bc652", null, "Admin", "Admin" }
                });
        }
    }
}
