using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class ApplyResponse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e0a94b4-8369-4076-a6ce-6512e1a9c28c", "AQAAAAIAAYagAAAAED1SVtTg2s8inL+e9bixeiz+kuv8pN73sAnNpNPh6vDyPf8W5IXkm4Iziz4Hmdm7jw==", "f8c53a67-c418-4990-beb0-9562fe79cb36" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7068f0e-c617-4005-9733-0107dc58db3f", "AQAAAAIAAYagAAAAEONqWIcFHsiKmJltIC3U7V8mr3Ia8y/TbvKWeleJNCmU527/JDoigMxrZEEQwLFQqA==", "e8dd908e-43e1-49a4-89c6-3ed223b87a2a" });
        }
    }
}
