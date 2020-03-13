using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class CriacaoDatabaseETabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atributo",
                columns: table => new
                {
                    IdAtributo = table.Column<Guid>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true),
                    IdConta = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    IdTipoAtributo = table.Column<Guid>(nullable: false),
                    TamanhoMaximo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo", x => x.IdAtributo);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    IdModelo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.IdModelo);
                });

            migrationBuilder.CreateTable(
                name: "ModeloAtributo",
                columns: table => new
                {
                    IdModeloAtributo = table.Column<Guid>(nullable: false),
                    IdModelo = table.Column<Guid>(nullable: false),
                    IdAtributo = table.Column<Guid>(nullable: false),
                    Ordem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloAtributo", x => x.IdModeloAtributo);
                });

            migrationBuilder.CreateTable(
                name: "TipoAtributo",
                columns: table => new
                {
                    IdTipoAtributo = table.Column<Guid>(nullable: false),
                    IdConta = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    IsAtivo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAtributo", x => x.IdTipoAtributo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atributo");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "ModeloAtributo");

            migrationBuilder.DropTable(
                name: "TipoAtributo");
        }
    }
}
