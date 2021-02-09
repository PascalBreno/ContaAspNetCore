using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AlteraTipoValorCorrigido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorOriginal",
                schema: "ContasBD",
                table: "Conta",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "ValorCorrigido",
                schema: "ContasBD",
                table: "Conta",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ValorOriginal",
                schema: "ContasBD",
                table: "Conta",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "ValorCorrigido",
                schema: "ContasBD",
                table: "Conta",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
