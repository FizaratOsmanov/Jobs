using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class ApplyResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "ApplyJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7068f0e-c617-4005-9733-0107dc58db3f", "AQAAAAIAAYagAAAAEONqWIcFHsiKmJltIC3U7V8mr3Ia8y/TbvKWeleJNCmU527/JDoigMxrZEEQwLFQqA==", "e8dd908e-43e1-49a4-89c6-3ed223b87a2a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "ApplyJobs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ef72565-a108-421d-b1c9-39886fae4d91", "AQAAAAIAAYagAAAAED66ng8YXe2slEpNfaOa0Qc5bnUjTS0+dqofKHqV6fGPoeGzrVd9V1cpIHrOAFoY8A==", "e76e9f74-d3ab-4b76-a027-00b291912466" });
        }
    }
}
