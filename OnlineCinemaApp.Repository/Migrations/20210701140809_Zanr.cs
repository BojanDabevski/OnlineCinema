using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineCinemaApp.Repository.Migrations
{
    public partial class Zanr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Products");
        }
    }
}
