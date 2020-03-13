using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class DeleteVersaoModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Versao",
                table: "Modelo",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Versao",
                table: "Modelo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long));
        }
    }
}
