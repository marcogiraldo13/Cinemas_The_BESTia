using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContext.Migrations
{
    public partial class ModifySeatxFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatxFunction_Functions_functionId",
                table: "SeatxFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatxFunction_Seates_seatId",
                table: "SeatxFunction");

            migrationBuilder.AlterColumn<int>(
                name: "seatId",
                table: "SeatxFunction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "functionId",
                table: "SeatxFunction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatxFunction_Functions_functionId",
                table: "SeatxFunction",
                column: "functionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatxFunction_Seates_seatId",
                table: "SeatxFunction",
                column: "seatId",
                principalTable: "Seates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatxFunction_Functions_functionId",
                table: "SeatxFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatxFunction_Seates_seatId",
                table: "SeatxFunction");

            migrationBuilder.AlterColumn<int>(
                name: "seatId",
                table: "SeatxFunction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "functionId",
                table: "SeatxFunction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SeatxFunction_Functions_functionId",
                table: "SeatxFunction",
                column: "functionId",
                principalTable: "Functions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatxFunction_Seates_seatId",
                table: "SeatxFunction",
                column: "seatId",
                principalTable: "Seates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
