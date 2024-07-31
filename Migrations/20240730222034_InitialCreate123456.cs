using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate123456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Address_idAddress",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_DétailsCommande_Commande_idCommande",
                table: "DétailsCommande");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_DétailsCommande_idCommande",
                table: "DétailsCommande");

            migrationBuilder.DropIndex(
                name: "IX_Commande_idAddress",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "idCommande",
                table: "DétailsCommande");

            migrationBuilder.DropColumn(
                name: "idAddress",
                table: "Commande");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "User",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CommandeId",
                table: "DétailsCommande",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DétailsCommande_CommandeId",
                table: "DétailsCommande",
                column: "CommandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DétailsCommande_Commande_CommandeId",
                table: "DétailsCommande",
                column: "CommandeId",
                principalTable: "Commande",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DétailsCommande_Commande_CommandeId",
                table: "DétailsCommande");

            migrationBuilder.DropIndex(
                name: "IX_DétailsCommande_CommandeId",
                table: "DétailsCommande");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "State",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "DétailsCommande");

            migrationBuilder.AddColumn<int>(
                name: "idCommande",
                table: "DétailsCommande",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                    FirstName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DétailsCommande_idCommande",
                table: "DétailsCommande",
                column: "idCommande");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_idAddress",
                table: "Commande",
                column: "idAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Address_idAddress",
                table: "Commande",
                column: "idAddress",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DétailsCommande_Commande_idCommande",
                table: "DétailsCommande",
                column: "idCommande",
                principalTable: "Commande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
