using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContext.Migrations
{
    public partial class ModifyCostBookingTodouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "booking_cost",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "booking_cost",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
