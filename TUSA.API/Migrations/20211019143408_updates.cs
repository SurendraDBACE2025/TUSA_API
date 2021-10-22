using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserLoginFail");

            migrationBuilder.DropTable(
                name: "UserLoginLog");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.CreateTable(
                name: "role_master",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_master", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "user_login_fail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loginat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_fail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_type_master",
                columns: table => new
                {
                    user_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_type_master", x => x.user_type_id);
                });

            migrationBuilder.CreateTable(
                name: "user_master",
                columns: table => new
                {
                    user_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    contact_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    user_type_id = table.Column<int>(type: "int", nullable: false),
                    user_type_id1 = table.Column<int>(type: "int", nullable: true),
                    last_login_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    password_changed_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activation_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    reset_password_date = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    last_reset_attempt_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refresh_token_expiryat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_activated = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    is_deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_master", x => x.user_name);
                    table.ForeignKey(
                        name: "FK_user_master_user_type_master_user_type_id1",
                        column: x => x.user_type_id1,
                        principalTable: "user_type_master",
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_login_log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_masteruser_name = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    loginat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_login_log_user_master_user_masteruser_name",
                        column: x => x.user_masteruser_name,
                        principalTable: "user_master",
                        principalColumn: "user_name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_login_log_user_masteruser_name",
                table: "user_login_log",
                column: "user_masteruser_name");

            migrationBuilder.CreateIndex(
                name: "IX_user_master_user_type_id1",
                table: "user_master",
                column: "user_type_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_master");

            migrationBuilder.DropTable(
                name: "user_login_fail");

            migrationBuilder.DropTable(
                name: "user_login_log");

            migrationBuilder.DropTable(
                name: "user_master");

            migrationBuilder.DropTable(
                name: "user_type_master");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Role_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginFail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginFail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    User_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    User_Type_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.User_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activation_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contact_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    First_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Is_Activated = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Is_Active = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Is_Deleted = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Last_Login_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Last_Reset_Attempt_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password_Changed_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reset_Password_Date = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type_Id = table.Column<int>(type: "int", nullable: false),
                    User_Type_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Name);
                    table.ForeignKey(
                        name: "FK_Users_UserType_User_Type_Id1",
                        column: x => x.User_Type_Id1,
                        principalTable: "UserType",
                        principalColumn: "User_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginLog_Users_User_Name",
                        column: x => x.User_Name,
                        principalTable: "Users",
                        principalColumn: "User_Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLog_User_Name",
                table: "UserLoginLog",
                column: "User_Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_Type_Id1",
                table: "Users",
                column: "User_Type_Id1");
        }
    }
}
