using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AdicionasoftDelet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContaId",
                schema: "ContasBD",
                table: "Conta",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "ContasBD",
                table: "Conta",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "ContasBD",
                table: "Conta");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "ContasBD",
                table: "Conta",
                newName: "ContaId");
        }
    }
}
