using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class initeel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_customerBasketeId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "customerBasketeId",
                table: "BasketItem");

            migrationBuilder.AddColumn<string>(
                name: "CustomerBasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_CustomerBasketId",
                table: "BasketItem",
                column: "CustomerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_CustomerBasketId",
                table: "BasketItem",
                column: "CustomerBasketId",
                principalTable: "CustomerBasket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_CustomerBasketId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_CustomerBasketId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "BasketItem");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "BasketItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "customerBasketeId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_customerBasketeId",
                table: "BasketItem",
                column: "customerBasketeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem",
                column: "customerBasketeId",
                principalTable: "CustomerBasket",
                principalColumn: "Id");
        }
    }
}
