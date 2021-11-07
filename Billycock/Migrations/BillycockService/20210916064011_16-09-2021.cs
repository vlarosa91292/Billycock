using Microsoft.EntityFrameworkCore.Migrations;

namespace Billycock.Migrations
{
    public partial class _16092021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fechaInscripcion",
                table: "USUARIO",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true,
                oldDefaultValueSql: "CAST(CAST(GETUTCDATE() AS DATETIMEOFFSET) AT TIME ZONE 'CENTRAL STANDARD TIME (MEXICO)' AS DATETIME)");

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "PLATAFORMACUENTA",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "integracion",
                table: "HISTORIA",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fecha",
                table: "HISTORIA",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fechaInscripcion",
                table: "USUARIO",
                type: "varchar(50)",
                nullable: true,
                defaultValueSql: "CAST(CAST(GETUTCDATE() AS DATETIMEOFFSET) AT TIME ZONE 'CENTRAL STANDARD TIME (MEXICO)' AS DATETIME)",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "PLATAFORMACUENTA",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "integracion",
                table: "HISTORIA",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fecha",
                table: "HISTORIA",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }
    }
}
