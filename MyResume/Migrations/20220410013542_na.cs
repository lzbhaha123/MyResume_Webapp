using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyResume.Migrations
{
    public partial class na : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pictrue",
                table: "Article",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pictrue",
                table: "Article");
        }
    }
}
