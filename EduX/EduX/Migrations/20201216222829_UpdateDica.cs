using Microsoft.EntityFrameworkCore.Migrations;

namespace EduX.Migrations
{
    public partial class UpdateDica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "byUsuario",
                table: "Dica",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "byUsuario",
                table: "Dica");
        }
    }
}
