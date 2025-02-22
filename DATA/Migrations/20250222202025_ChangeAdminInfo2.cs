using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminInfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93e5a2d7-1fd6-49f1-b348-cc68bef56b50", "ADMIN", "AQAAAAIAAYagAAAAEJPCzFrjjFDpRDa4qs6oUIzdU0mX7BFTUW9ahzLNGqpOO3541D+9wxIwaK4L0vShsA==", "39482938-fcfd-45f2-a1e7-9de400b92293" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7156699-9cfe-4e91-8cfd-78c2481e2966", "FIZARET", "AQAAAAIAAYagAAAAEKiB4XT2nHFGd+oyh5nrd4S7vz6MZElIFhrWTuMT0eQPwbEQ2CNm3y7GhSXM4Lm87Q==", "a5ffea02-ad9e-46da-be1a-031e0c45e293" });
        }
    }
}
