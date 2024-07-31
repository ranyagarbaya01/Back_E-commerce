using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idAddress",
                table: "Commande",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DétailsCommande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qte = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PrixTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    idProduit = table.Column<int>(type: "int", nullable: false),
                    idCommande = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DétailsCommande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DétailsCommande_Commande_idCommande",
                        column: x => x.idCommande,
                        principalTable: "Commande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DétailsCommande_Produit_idProduit",
                        column: x => x.idProduit,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_idAddress",
                table: "Commande",
                column: "idAddress");

            migrationBuilder.CreateIndex(
                name: "IX_DétailsCommande_idCommande",
                table: "DétailsCommande",
                column: "idCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DétailsCommande_idProduit",
                table: "DétailsCommande",
                column: "idProduit");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Address_idAddress",
                table: "Commande",
                column: "idAddress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Address_idAddress",
                table: "Commande");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DétailsCommande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_idAddress",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "idAddress",
                table: "Commande");
        }
    }
}
