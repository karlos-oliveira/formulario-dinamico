using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class CriacaoCamposMultiplaEscolhaEOpcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MultiplaEscolha",
                table: "ModeloAtributo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Opcoes",
                table: "ModeloAtributo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MultiplaEscolha",
                table: "ModeloAtributo");

            migrationBuilder.DropColumn(
                name: "Opcoes",
                table: "ModeloAtributo");
        }
    }
}
