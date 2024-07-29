using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store.Migrations
{
    /// <inheritdoc />
    public partial class inite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem");

            migrationBuilder.AlterColumn<string>(
                name: "customerBasketeId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem",
                column: "customerBasketeId",
                principalTable: "CustomerBasket",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem");

            migrationBuilder.AlterColumn<string>(
                name: "customerBasketeId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_CustomerBasket_customerBasketeId",
                table: "BasketItem",
                column: "customerBasketeId",
                principalTable: "CustomerBasket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
