using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AdicionaDiasDeAtrasoNaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                schema: "ContasBD",
                table: "Conta",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "DiasDeAtraso",
                schema: "ContasBD",
                table: "Conta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiasDeAtraso",
                schema: "ContasBD",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "ContasBD",
                table: "Conta",
                newName: "status");
        }
    }
}
