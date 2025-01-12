using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRellForUserAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdOwner",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserIdOwner",
                table: "Product",
                column: "UserIdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserIdOwner",
                table: "Product",
                column: "UserIdOwner",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserIdOwner",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserIdOwner",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserIdOwner",
                table: "Product");
        }
    }
}