using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConquistasOcultas",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConquistasTotais",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConquistasOcultas",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ConquistasTotais",
                table: "Usuario");
        }
    }
}
