using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class reledit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_UserId",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Group",
                newName: "UserOwner");

            migrationBuilder.RenameIndex(
                name: "IX_Group_UserId",
                table: "Group",
                newName: "IX_Group_UserOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_UserOwner",
                table: "Group",
                column: "UserOwner",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_UserOwner",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "UserOwner",
                table: "Group",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_UserOwner",
                table: "Group",
                newName: "IX_Group_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_UserId",
                table: "Group",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}