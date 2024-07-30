using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTTC",
                table: "Produit",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Heure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTTC = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalTVA = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalHT = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    FraisLivraison = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commande_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_idUser",
                table: "Commande",
                column: "idUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrixTTC",
                table: "Produit",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");
        }
    }
}
