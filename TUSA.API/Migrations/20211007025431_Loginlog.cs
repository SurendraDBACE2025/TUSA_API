using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TUSA.API.Migrations
{
    public partial class Loginlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
