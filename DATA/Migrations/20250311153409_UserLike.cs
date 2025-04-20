using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class UserLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLike_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLike_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c13b3d-7adc-4674-ab75-5d42152ab75f", "AQAAAAIAAYagAAAAEJUxZF94zarb5Rz3sKTngaZMYcdvNf/iIZvSQ51dKCxMX5D8rX1Bhfm/3hoUB3RtZg==", "9b9ddb11-0c13-4755-bae7-3da7d21d22f5" });

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_JobId",
                table: "UserLike",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLike_UserId",
                table: "UserLike",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLike");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cab40485-417f-4a9d-a1ca-7096757c07a0", "AQAAAAIAAYagAAAAEMu11QcUf5BqUUQ9E7f0x3kAb7rGRTiVGA8uzAVB2cLoksp7iPqSQzrbhYkylkmAiQ==", "2af831a5-c47d-4d58-a662-43a534daeefe" });
        }
    }
}
