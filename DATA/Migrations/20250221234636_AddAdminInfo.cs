using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "AspNetUsers",
                newName: "Profession");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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
                values: new object[] { "9418a5f2-920a-48aa-8e48-9a7b388a1fed", 0, "Baku", "cbdc8d88-515f-4670-b9e6-78a2dcd3c170", "Azerbaijan", "fizaratzo-ab205@code.edu.az", false, "Fizaret", "Osmanov", false, null, null, "FIZARET", "AQAAAAIAAYagAAAAEG1SjVcZ9mmAXgRse207ImIWNB6BmnFF9rtzav5gC7auHy104GFKqCj/fGcqOuDXog==", "+994 (50) 732 5300", false, "admin.jpg", "Developer", "2efb8e57-5e46-4492-958e-aa7c5dec3eb8", false, "fizaret" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "021a3b3d-22f9-42e7-9aa3-7a3b09375ff5", "9418a5f2-920a-48aa-8e48-9a7b388a1fed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "AspNetUsers",
                newName: "ImgPath");

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
    }
}
