using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class editrelationgroup : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateTable(
                name: "GroupsUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserOwner = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsUser", x => new { x.UserId, x.UserOwner });
                    table.ForeignKey(
                        name: "FK_GroupsUser_Group_UserOwner",
                        column: x => x.UserOwner,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupsUser_UserOwner",
                table: "GroupsUser",
                column: "UserOwner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupsUser");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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