using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX.Migrations
{
    public partial class UpdateUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurtidasTotais",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostagensTotais",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurtidasTotais",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PostagensTotais",
                table: "Usuario");
        }
    }
}
