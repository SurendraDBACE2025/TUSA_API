using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class usermadule_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLog_Users_UserId",
                table: "UserLoginLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLog_UserId",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NoOfWrongs",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "CanEdit",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Cards",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Menu",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Users",
                newName: "User_Type_Id");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "Users",
                newName: "Password_Changed_Date");

            migrationBuilder.RenameColumn(
                name: "ExpireOn",
                table: "Users",
                newName: "Last_Reset_Attempt_Time");

            migrationBuilder.RenameColumn(
                name: "AddedAt",
                table: "Users",
                newName: "Last_Login_Time");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserLoginLog",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "UserLoginFail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Roles",
                newName: "Role_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Activation_code",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact_Number",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email_Address",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Is_Activated",
                table: "Users",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Is_Active",
                table: "Users",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Is_Deleted",
                table: "Users",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reset_Password_Date",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_Type_Id1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "UserLoginLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserLoginLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "UserLoginLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "UserLoginLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "UserLoginLog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name1",
                table: "UserLoginLog",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role_Name",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "User_Name");

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    User_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.User_Type_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users",
                column: "User_Type_Id1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_User_Type_Id1",
                table: "Users",
                column: "User_Type_Id1",
                principalTable: "UserType",
                principalColumn: "User_Type_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginLog_Users_User_Name1",
                table: "UserLoginLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_User_Type_Id1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLoginLog_User_Name1",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Activation_code",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Contact_Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Is_Activated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Is_Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Reset_Password_Date",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_Type_Id1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "User_Name1",
                table: "UserLoginLog");

            migrationBuilder.DropColumn(
                name: "Role_Name",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "User_Type_Id",
                table: "Users",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Password_Changed_Date",
                table: "Users",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "Last_Reset_Attempt_Time",
                table: "Users",
                newName: "ExpireOn");

            migrationBuilder.RenameColumn(
                name: "Last_Login_Time",
                table: "Users",
                newName: "AddedAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLoginLog",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserLoginFail",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Role_Id",
                table: "Roles",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfWrongs",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserLoginLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CanEdit",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cards",
                table: "Roles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Menu",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privilege = table.Column<int>(type: "int", nullable: false),
                    SNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pages_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Privilege = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLog_UserId",
                table: "UserLoginLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GroupId",
                table: "Pages",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_PageId",
                table: "RolePrivileges",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_RoleId",
                table: "RolePrivileges",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginLog_Users_UserId",
                table: "UserLoginLog",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
