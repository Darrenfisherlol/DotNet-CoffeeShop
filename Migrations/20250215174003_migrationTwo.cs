using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class migrationTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Coffees_CoffeeId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CoffeeId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "Sales");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaleId = table.Column<int>(type: "integer", nullable: false),
                    CoffeeId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CoffeeId",
                table: "OrderDetails",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SaleId",
                table: "OrderDetails",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "CoffeeId",
                table: "Sales",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CoffeeId",
                table: "Sales",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Coffees_CoffeeId",
                table: "Sales",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
