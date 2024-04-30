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
            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Reaction_IDReaction",
                table: "ImageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChatRooms",
                table: "UserChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDReaction",
                table: "ImageData");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d68c9c-53fd-4df3-b58b-a3507746bd69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f27af5ab-d808-45e2-bafd-a8b35837f968");

            migrationBuilder.DropColumn(
                name: "IDReaction",
                table: "ImageData");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "UserChatRooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChatRooms",
                table: "UserChatRooms",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "BlockedAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDBlockedUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BlockedAccount_AspNetUsers_IDBlockedUser",
                        column: x => x.IDBlockedUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlockedAccount_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessagesUserChatRooms",
                columns: table => new
                {
                    IDMessages = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUserChatRooms = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesUserChatRooms", x => new { x.IDMessages, x.IDUserChatRooms });
                    table.ForeignKey(
                        name: "FK_MessagesUserChatRooms_Messages_IDMessages",
                        column: x => x.IDMessages,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessagesUserChatRooms_UserChatRooms_IDUserChatRooms",
                        column: x => x.IDUserChatRooms,
                        principalTable: "UserChatRooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipAction",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDRelatedUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RelationshipAction_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelationshipAction_AspNetUsers_IDRelatedUser",
                        column: x => x.IDRelatedUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelationshipAction_AspNetUsers_IDUser",
                        column: x => x.IDUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bed94919-15a5-4b6b-a76a-27bed371346f", null, "Client", "Client" },
                    { "ca69af81-c982-4f9a-aba2-aeb3423bc652", null, "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserChatRooms_IDChatRoom",
                table: "UserChatRooms",
                column: "IDChatRoom");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedAccount_IDBlockedUser",
                table: "BlockedAccount",
                column: "IDBlockedUser");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedAccount_IDUser",
                table: "BlockedAccount",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesUserChatRooms_IDUserChatRooms",
                table: "MessagesUserChatRooms",
                column: "IDUserChatRooms");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipAction_ApplicationUserId",
                table: "RelationshipAction",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipAction_IDRelatedUser",
                table: "RelationshipAction",
                column: "IDRelatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipAction_IDUser",
                table: "RelationshipAction",
                column: "IDUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedAccount");

            migrationBuilder.DropTable(
                name: "MessagesUserChatRooms");

            migrationBuilder.DropTable(
                name: "RelationshipAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChatRooms",
                table: "UserChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_UserChatRooms_IDChatRoom",
                table: "UserChatRooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bed94919-15a5-4b6b-a76a-27bed371346f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca69af81-c982-4f9a-aba2-aeb3423bc652");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "UserChatRooms");

            migrationBuilder.AddColumn<Guid>(
                name: "IDReaction",
                table: "ImageData",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChatRooms",
                table: "UserChatRooms",
                columns: new[] { "IDChatRoom", "IDUser" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d68c9c-53fd-4df3-b58b-a3507746bd69", null, "Client", "Client" },
                    { "f27af5ab-d808-45e2-bafd-a8b35837f968", null, "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDReaction",
                table: "ImageData",
                column: "IDReaction");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Reaction_IDReaction",
                table: "ImageData",
                column: "IDReaction",
                principalTable: "Reaction",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
