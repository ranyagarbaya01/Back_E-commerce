using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "User",
                type: "nvarchar(255)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
