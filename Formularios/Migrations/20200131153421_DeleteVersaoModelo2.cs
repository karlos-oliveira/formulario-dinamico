using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class DeleteVersaoModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Versao",
                table: "Modelo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Versao",
                table: "Modelo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
