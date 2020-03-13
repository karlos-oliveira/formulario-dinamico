using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formularios.Migrations
{
    public partial class DeletIdContaTipoAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "TipoAtributo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "TipoAtributo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
