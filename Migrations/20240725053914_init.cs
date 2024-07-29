using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketId",
                table: "BasketItem");

            migrationBuilder.RenameColumn(
                name: "customerBasketId",
                table: "BasketItem",
                newName: "customerBasketeId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_customerBasketId",
                table: "BasketItem",
                newName: "IX_BasketItem_customerBasketeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem",
                column: "customerBasketeId",
                principalTable: "CustomerBasket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem");

            migrationBuilder.RenameColumn(
                name: "customerBasketeId",
                table: "BasketItem",
                newName: "customerBasketId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketItem_customerBasketeId",
                table: "BasketItem",
                newName: "IX_BasketItem_customerBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketId",
                table: "BasketItem",
                column: "customerBasketId",
                principalTable: "CustomerBasket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
