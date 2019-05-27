using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContext.Migrations
{
    public partial class ModifyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Functions_functionsId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_functionsId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "functionsId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "SeatxFunction",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Booking",
                newName: "movieId");

            migrationBuilder.AddColumn<int>(
                name: "functionId",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Booking",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_functionId",
                table: "Booking",
                column: "functionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Functions_functionId",
                table: "Booking",
                column: "functionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Functions_functionId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_functionId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "functionId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "SeatxFunction",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "Booking",
                newName: "MovieId");

            migrationBuilder.AddColumn<int>(
                name: "functionsId",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_functionsId",
                table: "Booking",
                column: "functionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Functions_functionsId",
                table: "Booking",
                column: "functionsId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
