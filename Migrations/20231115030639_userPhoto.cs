using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeBoxBE.Migrations
{
    /// <inheritdoc />
    public partial class userPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "Reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "photoUrl", "userName" },
                values: new object[] { "https://avatars.githubusercontent.com/u/77301013?v=4", "Maddihalee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Reviews");
        }
    }
}
