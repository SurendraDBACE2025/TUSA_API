using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class user_master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLog_Users_User_Name1",
                table: "UserLoginLog");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLog_User_Name1",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "User_Name1",
                table: "UserLoginLog");

           

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "UserLoginLog",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "UserLoginLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLog_User_Name",
                table: "UserLoginLog",
                column: "User_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLog_Users_User_Name",
                table: "UserLoginLog",
                column: "User_Name",
                principalTable: "Users",
                principalColumn: "User_Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLog_Users_User_Name",
                table: "UserLoginLog");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLog_User_Name",
                table: "UserLoginLog");

          

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "UserLoginLog");

            migrationBuilder.AlterColumn<string>(
                name: "User_Name",
                table: "UserLoginLog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name1",
                table: "UserLoginLog",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLog_User_Name1",
                table: "UserLoginLog",
                column: "User_Name1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLog_Users_User_Name1",
                table: "UserLoginLog",
                column: "User_Name1",
                principalTable: "Users",
                principalColumn: "User_Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
