using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class changeAppUserIdStringToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6adf60d6-b26a-4fe5-9f52-2778cc3d9e86", "AQAAAAIAAYagAAAAEPAx7WuCaaZNV9H1rRTrl7oSkrVm6s69Q5/N4cLUOAOlBefUdSvc0ZONw6OVtdy7rg==", "66b7b494-627e-4221-ac97-2d467f171507" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId1",
                table: "Comments",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId1",
                table: "Comments",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b15c66b-dbc5-4597-b43d-37dad46a92fe", "AQAAAAIAAYagAAAAEDCFCLHM0EIWexiv3oQXeDsI4geJ1R0rxLPLC0lIRU6jAUOljbjAF6XXavNiUeOU+w==", "f37afb2b-be8f-44d0-82b0-55a8ae10fb6f" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
