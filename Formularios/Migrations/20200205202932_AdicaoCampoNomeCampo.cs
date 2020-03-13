using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class AdicaoCampoNomeCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCampo",
                table: "Atributo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCampo",
                table: "Atributo");
        }
    }
}
