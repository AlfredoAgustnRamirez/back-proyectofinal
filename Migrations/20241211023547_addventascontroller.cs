using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCategoryCrud.Migrations
{
    /// <inheritdoc />
    public partial class addventascontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasItems_Products_ProductoId",
                table: "VentasItems");

            migrationBuilder.DropIndex(
                name: "IX_VentasItems_ProductoId",
                table: "VentasItems");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "VentasItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VentasItems_ProductsId",
                table: "VentasItems",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentasItems_Products_ProductsId",
                table: "VentasItems",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasItems_Products_ProductsId",
                table: "VentasItems");

            migrationBuilder.DropIndex(
                name: "IX_VentasItems_ProductsId",
                table: "VentasItems");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "VentasItems");

            migrationBuilder.CreateIndex(
                name: "IX_VentasItems_ProductoId",
                table: "VentasItems",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentasItems_Products_ProductoId",
                table: "VentasItems",
                column: "ProductoId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
