using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContext.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "vote_average",
                table: "Movies",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Photo_Link",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "adult",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "backdrop_path",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "popularity",
                table: "Movies",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "poster_path",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "video",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "vote_count",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo_Link",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "adult",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "backdrop_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "popularity",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "poster_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "video",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "vote_count",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "vote_average",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }
    }
}
