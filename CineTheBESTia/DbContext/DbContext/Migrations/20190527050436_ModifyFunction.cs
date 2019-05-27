using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContext.Migrations
{
    public partial class ModifyFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Functions");

            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "Functions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "details",
                table: "Functions");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Functions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                table: "Functions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
