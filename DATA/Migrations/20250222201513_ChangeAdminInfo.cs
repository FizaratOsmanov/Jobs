using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminInfo : Migration
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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb7c4e4a-6dfd-4681-a78f-9c5a9f90ed4c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5", "9418a5f2-920a-48aa-8e48-9a7b388a1fed" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Comments",
                newName: "FirstName");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cedefe1-ed59-4a08-89c2-1b4bc2ed00bb", null, "User", "USER" },
                    { "dfec424a-b225-4e2e-bd46-4b041b13abda", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Profession", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3", 0, "Baku", "e7156699-9cfe-4e91-8cfd-78c2481e2966", "Azerbaijan", "fizaratzo-ab205@code.edu.az", false, "Fizaret", "Osmanov", false, null, null, "FIZARET", "AQAAAAIAAYagAAAAEKiB4XT2nHFGd+oyh5nrd4S7vz6MZElIFhrWTuMT0eQPwbEQ2CNm3y7GhSXM4Lm87Q==", "+994 (50) 732 5300", false, "AdminProfile.webp", "Developer", "a5ffea02-ad9e-46da-be1a-031e0c45e293", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dfec424a-b225-4e2e-bd46-4b041b13abda", "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3" });

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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cedefe1-ed59-4a08-89c2-1b4bc2ed00bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dfec424a-b225-4e2e-bd46-4b041b13abda", "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfec424a-b225-4e2e-bd46-4b041b13abda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Comments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Comments",
                newName: "ImgPath");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5", null, "Admin", "ADMIN" },
                    { "bb7c4e4a-6dfd-4681-a78f-9c5a9f90ed4c", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "Profession", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9418a5f2-920a-48aa-8e48-9a7b388a1fed", 0, "Baku", "0102ba1d-841e-477c-be5b-f96d14410a85", "Azerbaijan", "fizaratzo-ab205@code.edu.az", false, "Fizaret", "Osmanov", false, null, null, "FIZARET", "AQAAAAIAAYagAAAAEFShmzcN4deDBt4VMnhHeZsMKCVWzXebDhGnlFPtUCxX3vLG+y4l0tWobMQlrz8uYA==", "+994 (50) 732 5300", false, "admin.jpg", "Developer", "bdee3be5-a60f-477f-be71-4f503c510f3e", false, "fizaret" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5", "9418a5f2-920a-48aa-8e48-9a7b388a1fed" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
