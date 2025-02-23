using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class addedApplyAndJobOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "ApplyJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cab40485-417f-4a9d-a1ca-7096757c07a0", "AQAAAAIAAYagAAAAEMu11QcUf5BqUUQ9E7f0x3kAb7rGRTiVGA8uzAVB2cLoksp7iPqSQzrbhYkylkmAiQ==", "2af831a5-c47d-4d58-a662-43a534daeefe" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyJobs_JobId",
                table: "ApplyJobs",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyJobs_Jobs_JobId",
                table: "ApplyJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplyJobs_Jobs_JobId",
                table: "ApplyJobs");

            migrationBuilder.DropIndex(
                name: "IX_ApplyJobs_JobId",
                table: "ApplyJobs");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "ApplyJobs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "267b2cd8-07b6-4c0d-946b-0d9125a8d4c8", "AQAAAAIAAYagAAAAEKw13+LQhdDWUxqoNP+HWfQi4gLs5Qk2H1WE5XtCgXQRTvuejutCrL6sDd6c7R4hHw==", "90f39fe7-0bd2-4775-9089-e54950b21e4d" });
        }
    }
}
