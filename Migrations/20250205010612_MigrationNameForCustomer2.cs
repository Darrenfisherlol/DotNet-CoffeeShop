using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNameForCustomer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Coffee_CoffeeId1",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CoffeeId1",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CoffeeId1",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "CoffeeId",
                table: "Sale",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CoffeeId",
                table: "Sale",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Coffee_CoffeeId",
                table: "Sale",
                column: "CoffeeId",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Coffee_CoffeeId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CoffeeId",
                table: "Sale");

            migrationBuilder.AlterColumn<string>(
                name: "CoffeeId",
                table: "Sale",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CoffeeId1",
                table: "Sale",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CoffeeId1",
                table: "Sale",
                column: "CoffeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Coffee_CoffeeId1",
                table: "Sale",
                column: "CoffeeId1",
                principalTable: "Coffee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
