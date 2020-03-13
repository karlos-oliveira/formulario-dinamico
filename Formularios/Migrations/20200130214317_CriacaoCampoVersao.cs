using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class CriacaoCampoVersao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "ModeloAtributo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Versao",
                table: "ModeloAtributo",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Versao",
                table: "Modelo",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "ModeloAtributo");

            migrationBuilder.DropColumn(
                name: "Versao",
                table: "ModeloAtributo");

            migrationBuilder.DropColumn(
                name: "Versao",
                table: "Modelo");
        }
    }
}
