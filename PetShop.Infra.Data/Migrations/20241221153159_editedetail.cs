using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class editedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Detail_UserId",
                table: "User_Detail");

            migrationBuilder.CreateIndex(
                name: "IX_User_Detail_UserId",
                table: "User_Detail",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Detail_UserId",
                table: "User_Detail");

            migrationBuilder.CreateIndex(
                name: "IX_User_Detail_UserId",
                table: "User_Detail",
                column: "UserId");
        }
    }
}