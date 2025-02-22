using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Comments",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11ff0bf6-bbd3-4cd6-97b1-b03870480862", "AQAAAAIAAYagAAAAEJkUZ/OHMMxwEGu+VYyDIgFa8r9n2eJ/FqI2XGajlhVYI3Jwa0T4WoOaPixwtol6+Q==", "c791a516-58eb-4e9b-9241-c6d4d3d8e235" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Comments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Comments",
                newName: "ImgPath");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9418a5f2-920a-48aa-8e48-9a7b388a1fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0102ba1d-841e-477c-be5b-f96d14410a85", "AQAAAAIAAYagAAAAEFShmzcN4deDBt4VMnhHeZsMKCVWzXebDhGnlFPtUCxX3vLG+y4l0tWobMQlrz8uYA==", "bdee3be5-a60f-477f-be71-4f503c510f3e" });
        }
    }
}
