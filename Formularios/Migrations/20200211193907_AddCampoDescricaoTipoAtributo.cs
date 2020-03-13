using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class AddCampoDescricaoTipoAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "TipoAtributo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "TipoAtributo");
        }
    }
}
