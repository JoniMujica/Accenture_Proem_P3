using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_StarWars.Migrations
{
    public partial class TipoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Personajes");
        }
    }
}
