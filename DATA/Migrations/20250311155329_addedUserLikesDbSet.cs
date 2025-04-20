using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class addedUserLikesDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_AspNetUsers_UserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_Jobs_JobId",
                table: "UserLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike");

            migrationBuilder.RenameTable(
                name: "UserLike",
                newName: "UserLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_UserId",
                table: "UserLikes",
                newName: "IX_UserLikes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_JobId",
                table: "UserLikes",
                newName: "IX_UserLikes_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae8d8dab-93be-444c-a171-13148b5024f5", "AQAAAAIAAYagAAAAEIiUtaKeahwxZrfz4g7ze2IxR+Ho5FZMXP+c/ayH2ywxO20c0e41BdpX2go9Jp5YLA==", "e3b29ab5-7416-4770-9cd9-59b41c03273b" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_Jobs_JobId",
                table: "UserLikes",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_Jobs_JobId",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.RenameTable(
                name: "UserLikes",
                newName: "UserLike");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_UserId",
                table: "UserLike",
                newName: "IX_UserLike_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_JobId",
                table: "UserLike",
                newName: "IX_UserLike_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ece08d2-d4a3-4d25-b78d-b75aa6651bd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c13b3d-7adc-4674-ab75-5d42152ab75f", "AQAAAAIAAYagAAAAEJUxZF94zarb5Rz3sKTngaZMYcdvNf/iIZvSQ51dKCxMX5D8rX1Bhfm/3hoUB3RtZg==", "9b9ddb11-0c13-4755-bae7-3da7d21d22f5" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_AspNetUsers_UserId",
                table: "UserLike",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_Jobs_JobId",
                table: "UserLike",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
