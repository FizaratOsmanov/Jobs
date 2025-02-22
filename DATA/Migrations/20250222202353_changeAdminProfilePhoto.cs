using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class changeAdminProfilePhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "74177cfc-ae74-4015-b269-c79ae782b2d7", "AQAAAAIAAYagAAAAEJrsIeMBxZ6NaVWhEnkW6QVno/Zw3eGDh45tOfRSyacjfHPedxRfcwVhLxz3Zn8DQA==", "Admin.webp", "d5a76c8a-181f-483c-9dcf-5c1fad2a6bb7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhotoPath", "SecurityStamp" },
                values: new object[] { "93e5a2d7-1fd6-49f1-b348-cc68bef56b50", "AQAAAAIAAYagAAAAEJPCzFrjjFDpRDa4qs6oUIzdU0mX7BFTUW9ahzLNGqpOO3541D+9wxIwaK4L0vShsA==", "AdminProfile.webp", "39482938-fcfd-45f2-a1e7-9de400b92293" });
        }
    }
}
