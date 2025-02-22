using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class addIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aa20729-5e62-402e-9060-31a1183376dd", null, "User", "USER" },
                    { "f8cfae31-a649-46d9-841d-48d8a8134eb6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImgPath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb519e3d-71d8-4a19-8d10-955e605c8adb", 0, "a117c05c-1398-4b52-bde1-3500e6184546", null, false, null, null, null, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEKDH5Ktt3Jb1C+peZiurTPzxFstZspL5IZDDEhFCjBtSrnlQf5RHPF8OvpgDjYr0/A==", null, false, "8ca9356f-dae0-4087-856e-5d7532f05975", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8cfae31-a649-46d9-841d-48d8a8134eb6", "bb519e3d-71d8-4a19-8d10-955e605c8adb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa20729-5e62-402e-9060-31a1183376dd");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8cfae31-a649-46d9-841d-48d8a8134eb6", "bb519e3d-71d8-4a19-8d10-955e605c8adb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8cfae31-a649-46d9-841d-48d8a8134eb6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb519e3d-71d8-4a19-8d10-955e605c8adb");
        }
    }
}
