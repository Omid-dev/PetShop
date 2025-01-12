using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UPDATETONAVGIATION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "Product",
                newName: "ProdcutId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderDetailId",
                table: "Product",
                newName: "IX_Product_ProdcutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderDetail_ProdcutId",
                table: "Product",
                column: "ProdcutId",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderDetail_ProdcutId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProdcutId",
                table: "Product",
                newName: "OrderDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProdcutId",
                table: "Product",
                newName: "IX_Product_OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailId",
                table: "Product",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }
    }
}