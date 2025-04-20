using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class PhotoPhotoIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ef72565-a108-421d-b1c9-39886fae4d91", "AQAAAAIAAYagAAAAED66ng8YXe2slEpNfaOa0Qc5bnUjTS0+dqofKHqV6fGPoeGzrVd9V1cpIHrOAFoY8A==", "e76e9f74-d3ab-4b76-a027-00b291912466" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae8d8dab-93be-444c-a171-13148b5024f5", "AQAAAAIAAYagAAAAEIiUtaKeahwxZrfz4g7ze2IxR+Ho5FZMXP+c/ayH2ywxO20c0e41BdpX2go9Jp5YLA==", "e3b29ab5-7416-4770-9cd9-59b41c03273b" });
        }
    }
}
