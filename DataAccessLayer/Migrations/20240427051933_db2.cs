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
                name: "FK_ImageData_AspNetUsers_ApplicationUserId",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Comment_CommentID",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Messages_MessagesID",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Post_PostID",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Reaction_ReactionID",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_ApplicationUserId",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_CommentID",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_MessagesID",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_PostID",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_ReactionID",
                table: "ImageData");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "309fe70c-7aef-49d7-8730-dd91494a952e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ac905b-d728-4e27-bbfa-23c042829efe");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "CommentID",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "MessagesID",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "ImageData");

            migrationBuilder.DropColumn(
                name: "ReactionID",
                table: "ImageData");

            migrationBuilder.AlterColumn<string>(
                name: "IDUser",
                table: "ImageData",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e1eb34f-4466-4d68-bc4b-66ffa58605e8", null, "Admin", "Admin" },
                    { "f47ff40b-26c1-4012-a514-107d1e9bb414", null, "Client", "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDComment",
                table: "ImageData",
                column: "IDComment");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDMessage",
                table: "ImageData",
                column: "IDMessage");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDPost",
                table: "ImageData",
                column: "IDPost");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDReaction",
                table: "ImageData",
                column: "IDReaction");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_IDUser",
                table: "ImageData",
                column: "IDUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_AspNetUsers_IDUser",
                table: "ImageData",
                column: "IDUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Comment_IDComment",
                table: "ImageData",
                column: "IDComment",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Messages_IDMessage",
                table: "ImageData",
                column: "IDMessage",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Post_IDPost",
                table: "ImageData",
                column: "IDPost",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Reaction_IDReaction",
                table: "ImageData",
                column: "IDReaction",
                principalTable: "Reaction",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_AspNetUsers_IDUser",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Comment_IDComment",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Messages_IDMessage",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Post_IDPost",
                table: "ImageData");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageData_Reaction_IDReaction",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDComment",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDMessage",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDPost",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDReaction",
                table: "ImageData");

            migrationBuilder.DropIndex(
                name: "IX_ImageData_IDUser",
                table: "ImageData");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1eb34f-4466-4d68-bc4b-66ffa58605e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f47ff40b-26c1-4012-a514-107d1e9bb414");

            migrationBuilder.AlterColumn<string>(
                name: "IDUser",
                table: "ImageData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ImageData",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentID",
                table: "ImageData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessagesID",
                table: "ImageData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "ImageData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReactionID",
                table: "ImageData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "309fe70c-7aef-49d7-8730-dd91494a952e", null, "Admin", "Admin" },
                    { "f6ac905b-d728-4e27-bbfa-23c042829efe", null, "Client", "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_ApplicationUserId",
                table: "ImageData",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_CommentID",
                table: "ImageData",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_MessagesID",
                table: "ImageData",
                column: "MessagesID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_PostID",
                table: "ImageData",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageData_ReactionID",
                table: "ImageData",
                column: "ReactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_AspNetUsers_ApplicationUserId",
                table: "ImageData",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Comment_CommentID",
                table: "ImageData",
                column: "CommentID",
                principalTable: "Comment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Messages_MessagesID",
                table: "ImageData",
                column: "MessagesID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Post_PostID",
                table: "ImageData",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageData_Reaction_ReactionID",
                table: "ImageData",
                column: "ReactionID",
                principalTable: "Reaction",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
