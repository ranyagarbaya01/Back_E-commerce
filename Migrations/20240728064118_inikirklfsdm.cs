using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class inikirklfsdm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Produit",
                newName: "PrixTTC");

            migrationBuilder.AddColumn<decimal>(
                name: "PrixHT",
                table: "Produit",
                type: "decimal(16,3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TVA",
                table: "Produit",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Produit",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixHT",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "TVA",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Produit");

            migrationBuilder.RenameColumn(
                name: "PrixTTC",
                table: "Produit",
                newName: "Prix");
        }
    }
}
