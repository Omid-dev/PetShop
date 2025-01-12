using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class reledit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_UserOwner",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_UserOwner",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "UserOwner",
                table: "Group");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserIdOwner",
                table: "Group",
                column: "UserIdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_UserIdOwner",
                table: "Group",
                column: "UserIdOwner",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_User_UserIdOwner",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_UserIdOwner",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "UserOwner",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserOwner",
                table: "Group",
                column: "UserOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_User_UserOwner",
                table: "Group",
                column: "UserOwner",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}