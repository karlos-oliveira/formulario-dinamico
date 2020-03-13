using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class CriacaoCampoObrigatoriedadeAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Obrigatorio",
                table: "ModeloAtributo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obrigatorio",
                table: "ModeloAtributo");
        }
    }
}
