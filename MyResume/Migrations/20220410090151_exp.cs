using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyResume.Migrations
{
    public partial class exp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "Experience",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture",
                table: "Experience");
        }
    }
}
