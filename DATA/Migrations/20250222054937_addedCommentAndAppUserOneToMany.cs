using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class addedCommentAndAppUserOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0102ba1d-841e-477c-be5b-f96d14410a85", "AQAAAAIAAYagAAAAEFShmzcN4deDBt4VMnhHeZsMKCVWzXebDhGnlFPtUCxX3vLG+y4l0tWobMQlrz8uYA==", "bdee3be5-a60f-477f-be71-4f503c510f3e" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbdc8d88-515f-4670-b9e6-78a2dcd3c170", "AQAAAAIAAYagAAAAEG1SjVcZ9mmAXgRse207ImIWNB6BmnFF9rtzav5gC7auHy104GFKqCj/fGcqOuDXog==", "2efb8e57-5e46-4492-958e-aa7c5dec3eb8" });
        }
    }
}
