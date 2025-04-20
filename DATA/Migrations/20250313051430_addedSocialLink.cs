using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class addedSocialLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c498e56-5682-4487-8213-bd54af4b7cc3", "AQAAAAIAAYagAAAAEKsAArTumk3H8PZ1/wPHYJWhXq/Z7RJo9y0+5TQOsVmA17TTuKa427pdn28WX7HyIg==", "9c453b5e-5e2b-4b4d-b51f-e0573e195f8d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27181e3c-a407-47aa-93ef-bb94508fec65", "AQAAAAIAAYagAAAAEAIlZwV1PbJDMd8Ls05krSZ2TsitYgYe3Wjb5AD7PqQGfU6ExseY+Z0jMYrA6pCDnA==", "5354b5b6-75a1-4067-849c-2d3b38b32ae1" });
        }
    }
}
